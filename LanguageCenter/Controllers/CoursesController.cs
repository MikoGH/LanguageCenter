using AutoMapper;
using LanguageCenter.Features.Courses.Commands.DeleteCourseById;
using LanguageCenter.Features.Courses.Commands.InsertCourse;
using LanguageCenter.Features.Courses.Commands.UpdateCourse;
using LanguageCenter.Features.Courses.Dtos;
using LanguageCenter.Features.Courses.Queries.GetAllCourses;
using LanguageCenter.Features.Courses.Queries.GetCourseById;
using LanguageCenter.Features.CoursesTutors.Commands.DeleteCourseTutor;
using LanguageCenter.Features.CoursesTutors.Commands.InsertCourseTutor;
using LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByCourseId;
using LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByPersonId;
using LanguageCenter.Features.Languages.Queries.ExistsLanguageById;
using LanguageCenter.Features.Levels.Queries.ExistsLevelById;
using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Features.Persons.Queries.GetPersonById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public CoursesController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<CourseEntity> courses = await mediator.Send(new GetAllCoursesQuery(), cancellationToken);
			if (courses == null)
				return NotFound();
			return Ok(courses);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			CourseEntity course = await mediator.Send(new GetCourseByIdQuery(id), cancellationToken);
			if (course == null)
				return NotFound();
			return Ok(course);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertCourseDto courseDto, CancellationToken cancellationToken)
		{
			if (!await mediator.Send(new ExistsLanguageByIdQuery(courseDto.LanguageId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsLevelByIdQuery(courseDto.LevelId), cancellationToken))
				return NotFound();
			if (courseDto.CountLessons < 0)
				return BadRequest();

			CourseEntity course = mapper.Map<CourseEntity>(courseDto);
			await mediator.Send(new InsertCourseCommand(course), cancellationToken);
			return Ok(course);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateCourseDto courseDto, CancellationToken cancellationToken)
		{
			CourseEntity course = await mediator.Send(new GetCourseByIdQuery(id), cancellationToken);
			if (course == null)	
				return NotFound();

			if (!await mediator.Send(new ExistsLanguageByIdQuery(course.LanguageId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsLevelByIdQuery(course.LevelId), cancellationToken))
				return NotFound();
			if (courseDto.CountLessons < 0)
				return BadRequest();

			course = mapper.Map(courseDto, course);

			await mediator.Send(new UpdateCourseCommand(course), cancellationToken);
			return Ok(course);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteCourseByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}

		[HttpGet("{id:int}/tutors")]
		public async Task<IActionResult> GetTutorsList([FromRoute] int id, CancellationToken cancellationToken)
		{
			IEnumerable<CourseTutorEntity> courseTutors = await mediator.Send(new GetCourseTutorByCourseIdQuery(id), cancellationToken);
			IEnumerable<PersonEntity> tutors = new List<PersonEntity>();
			foreach (CourseTutorEntity courseTutor in courseTutors)
			{
				tutors = tutors.Append(await mediator.Send(new GetPersonByIdQuery(courseTutor.PersonId), cancellationToken));
			}
			IEnumerable<GetPersonDto> tutorsDto = mapper.Map<IEnumerable<GetPersonDto>>(tutors);
			return Ok(tutorsDto);
		}

		[HttpPost("{id:int}/tutors")]
		public async Task<IActionResult> InsertTutor([FromRoute] int id, int personId, CancellationToken cancellationToken)
		{
			CourseTutorEntity courseTutor = new CourseTutorEntity
			{
				PersonId = personId,
				CourseId = id
			};
			await mediator.Send(new InsertCourseTutorCommand(courseTutor), cancellationToken);
			return Ok(courseTutor);
		}

		[HttpDelete("{id:int}/tutors")]
		public async Task<IActionResult> DeleteTutor([FromRoute] int id, int personId, CancellationToken cancellationToken)
		{
			CourseTutorEntity courseTutor = new CourseTutorEntity
			{
				PersonId = personId,
				CourseId = id
			};
			await mediator.Send(new DeleteCourseTutorCommand(courseTutor), cancellationToken);
			return Ok();
		}
	}
}
