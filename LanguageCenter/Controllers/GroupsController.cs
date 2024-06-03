using AutoMapper;
using LanguageCenter.Features.Courses.Queries.ExistsCourseById;
using LanguageCenter.Features.Groups.Commands.DeleteGroupById;
using LanguageCenter.Features.Groups.Commands.InsertGroup;
using LanguageCenter.Features.Groups.Commands.UpdateGroup;
using LanguageCenter.Features.Groups.Dtos;
using LanguageCenter.Features.Groups.Queries.GetAllGroups;
using LanguageCenter.Features.Groups.Queries.GetGroupById;
using LanguageCenter.Features.GroupsClients.Commands.DeleteGroupClient;
using LanguageCenter.Features.GroupsClients.Commands.InsertGroupClient;
using LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByGroupId;
using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Features.Persons.Queries.ExistsPersonById;
using LanguageCenter.Features.Persons.Queries.GetPersonById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupsController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public GroupsController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<GroupEntity> groups = await mediator.Send(new GetAllGroupsQuery(), cancellationToken);
			if (groups == null)
				return NotFound();
			return Ok(groups);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			GroupEntity group = await mediator.Send(new GetGroupByIdQuery(id), cancellationToken);
			if (group == null)
				return NotFound();
			return Ok(group);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertGroupDto groupDto, CancellationToken cancellationToken)
		{
			if (!await mediator.Send(new ExistsCourseByIdQuery(groupDto.CourseId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsPersonByIdQuery(groupDto.PersonId), cancellationToken))
				return NotFound();

			GroupEntity group = mapper.Map<GroupEntity>(groupDto);
			await mediator.Send(new InsertGroupCommand(group), cancellationToken);
			return Ok(group);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateGroupDto groupDto, CancellationToken cancellationToken)
		{
			GroupEntity group = await mediator.Send(new GetGroupByIdQuery(id), cancellationToken);
			if (group == null)
				return NotFound();

			if (!await mediator.Send(new ExistsCourseByIdQuery(groupDto.CourseId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsPersonByIdQuery(groupDto.PersonId), cancellationToken))
				return NotFound();

			group = mapper.Map(groupDto, group);

			await mediator.Send(new UpdateGroupCommand(group), cancellationToken);
			return Ok(group);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteGroupByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}

		[HttpGet("{id:int}/clients")]
		public async Task<IActionResult> GetClientsList([FromRoute] int id, CancellationToken cancellationToken)
		{
			IEnumerable<GroupClientEntity> groupClients = await mediator.Send(new GetGroupClientByGroupIdQuery(id), cancellationToken);
			IEnumerable<PersonEntity> clients = new List<PersonEntity>();
			foreach (GroupClientEntity groupClient in groupClients)
			{
				clients = clients.Append(await mediator.Send(new GetPersonByIdQuery(groupClient.PersonId), cancellationToken));
			}
			IEnumerable<GetPersonDto> clientsDto = mapper.Map<IEnumerable<GetPersonDto>>(clients);
			return Ok(clientsDto);
		}

		[HttpPost("{id:int}/clients")]
		public async Task<IActionResult> InsertTutor([FromRoute] int id, int personId, CancellationToken cancellationToken)
		{
			GroupClientEntity groupClient = new GroupClientEntity
			{
				PersonId = personId,
				GroupId = id
			};
			await mediator.Send(new InsertGroupClientCommand(groupClient), cancellationToken);
			return Ok(groupClient);
		}

		[HttpDelete("{id:int}/clients")]
		public async Task<IActionResult> DeleteTutor([FromRoute] int id, int personId, CancellationToken cancellationToken)
		{
			GroupClientEntity groupClient = new GroupClientEntity
			{
				PersonId = personId,
				GroupId = id
			};
			await mediator.Send(new DeleteGroupClientCommand(groupClient), cancellationToken);
			return Ok();
		}
	}
}
