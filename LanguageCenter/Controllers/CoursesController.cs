using AutoMapper;
using LanguageCenter.CQRS.Commands.Courses;
using LanguageCenter.CQRS.Queries.Courses;
using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ILanguageRepository languageRepository;
		private readonly ILevelRepository levelRepository;
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public CoursesController(ILanguageRepository languageRepository, ILevelRepository levelRepository, IMapper mapper, IMediator mediator)
		{
			this.languageRepository = languageRepository;
			this.levelRepository = levelRepository;
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
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

			if (!await languageRepository.ExistsByIdAsync(courseDto.LanguageId, cancellationToken))  //!
				return NotFound();
			if (!await levelRepository.ExistsByIdAsync(courseDto.LevelId, cancellationToken))  //!
				return NotFound();

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
	}
}
