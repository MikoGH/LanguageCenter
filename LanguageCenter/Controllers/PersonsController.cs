using AutoMapper;
using LanguageCenter.Features.Courses.Queries.GetCourseById;
using LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByPersonId;
using LanguageCenter.Features.Groups.Queries.GetGroupById;
using LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByPersonId;
using LanguageCenter.Features.Persons.Commands.DeletePersonById;
using LanguageCenter.Features.Persons.Commands.InsertPerson;
using LanguageCenter.Features.Persons.Commands.UpdatePerson;
using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Features.Persons.Queries.ExistsPersonByLogin;
using LanguageCenter.Features.Persons.Queries.GetAllPersons;
using LanguageCenter.Features.Persons.Queries.GetPersonById;
using LanguageCenter.Models;
using LanguageCenter.Modules.PasswordHasher;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanguageCenter.Controllers
{
	[Authorize(Roles = PersonEntity.Roles.Admin)]
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPasswordHasher passwordHasher;
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public PersonsController(IPasswordHasher passwordHasher, IMapper mapper, IMediator mediator)
		{
			this.passwordHasher = passwordHasher;
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<PersonEntity> persons = await mediator.Send(new GetAllPersonsQuery(), cancellationToken);
			if (persons == null)
				return NotFound();
			IEnumerable<GetPersonDto> personsDto = mapper.Map<IEnumerable<GetPersonDto>>(persons);
			return Ok(personsDto);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			PersonEntity person = await mediator.Send(new GetPersonByIdQuery(id), cancellationToken);
			if (person == null)
				return NotFound();
			GetPersonDto personDto = mapper.Map<GetPersonDto>(person);
			return Ok(personDto);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertPersonDto personDto, CancellationToken cancellationToken)
		{
			if (await mediator.Send(new ExistsPersonByLoginQuery(personDto.Login), cancellationToken))
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			PersonEntity person = mapper.Map<PersonEntity>(personDto);

			await mediator.Send(new InsertPersonCommand(person), cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdatePersonDto personDto, CancellationToken cancellationToken)
		{
			PersonEntity person = await mediator.Send(new GetPersonByIdQuery(id), cancellationToken);
			if (person == null)
				return NotFound();

			personDto.Password = passwordHasher.Generate(personDto.Password);
			person = mapper.Map<PersonEntity>(personDto);

			await mediator.Send(new UpdatePersonCommand(person), cancellationToken);
			GetPersonDto getPersonDto = mapper.Map<GetPersonDto>(person);
			return Ok(getPersonDto);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeletePersonByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}

		[HttpGet("{id:int}/courses")]
		public async Task<IActionResult> GetCoursesList([FromRoute] int id, CancellationToken cancellationToken)
		{
			IEnumerable<CourseTutorEntity> coursesTutor = await mediator.Send(new GetCourseTutorByPersonIdQuery(id), cancellationToken);
			IEnumerable<CourseEntity> courses = new List<CourseEntity>();
			foreach (CourseTutorEntity courseTutor in coursesTutor)
			{
				courses = courses.Append(await mediator.Send(new GetCourseByIdQuery(courseTutor.CourseId), cancellationToken));
			}
			return Ok(courses);
		}

		[HttpGet("{id:int}/groups")]
		public async Task<IActionResult> GetGroupsList([FromRoute] int id, CancellationToken cancellationToken)
		{
			IEnumerable<GroupClientEntity> groupsClient = await mediator.Send(new GetGroupClientByPersonIdQuery(id), cancellationToken);
			IEnumerable<GroupEntity> groups = new List<GroupEntity>();
			foreach (GroupClientEntity groupClient in groupsClient)
			{
				groups = groups.Append(await mediator.Send(new GetGroupByIdQuery(groupClient.GroupId), cancellationToken));
			}
			return Ok(groups);
		}
	}
}
