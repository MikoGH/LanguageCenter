using AutoMapper;
using LanguageCenter.Features.Classrooms.Queries.ExistsClassroomById;
using LanguageCenter.Features.Groups.Queries.ExistsGroupById;
using LanguageCenter.Features.Schedules.Commands.DeleteScheduleById;
using LanguageCenter.Features.Schedules.Commands.InsertSchedule;
using LanguageCenter.Features.Schedules.Commands.UpdateSchedule;
using LanguageCenter.Features.Schedules.Dtos;
using LanguageCenter.Features.Schedules.Queries.GetAllSchedules;
using LanguageCenter.Features.Schedules.Queries.GetScheduleById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchedulesController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public SchedulesController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<ScheduleEntity> schedules = await mediator.Send(new GetAllSchedulesQuery(), cancellationToken);
			if (schedules == null)
				return NotFound();
			return Ok(schedules);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			ScheduleEntity schedule = await mediator.Send(new GetScheduleByIdQuery(id), cancellationToken);
			if (schedule == null)
				return NotFound();
			return Ok(schedule);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertScheduleDto scheduleDto, CancellationToken cancellationToken)
		{
			if (!await mediator.Send(new ExistsClassroomByIdQuery(scheduleDto.ClassroomId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsGroupByIdQuery(scheduleDto.GroupId), cancellationToken))
				return NotFound();

			ScheduleEntity schedule = mapper.Map<ScheduleEntity>(scheduleDto);
			await mediator.Send(new InsertScheduleCommand(schedule), cancellationToken);
			return Ok(schedule);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateScheduleDto scheduleDto, CancellationToken cancellationToken)
		{
			ScheduleEntity schedule = await mediator.Send(new GetScheduleByIdQuery(id), cancellationToken);
			if (schedule == null)
				return NotFound();

			if (!await mediator.Send(new ExistsClassroomByIdQuery(schedule.ClassroomId), cancellationToken))
				return NotFound();
			if (!await mediator.Send(new ExistsGroupByIdQuery(schedule.GroupId), cancellationToken))
				return NotFound();

			schedule = mapper.Map(scheduleDto, schedule);

			await mediator.Send(new UpdateScheduleCommand(schedule), cancellationToken);
			return Ok(schedule);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteScheduleByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
