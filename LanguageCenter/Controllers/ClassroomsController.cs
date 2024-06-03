using AutoMapper;
using LanguageCenter.Features.Addresses.Queries.ExistsAddressById;
using LanguageCenter.Features.Classrooms.Commands.DeleteClassroomById;
using LanguageCenter.Features.Classrooms.Commands.InsertClassroom;
using LanguageCenter.Features.Classrooms.Commands.UpdateClassroom;
using LanguageCenter.Features.Classrooms.Dtos;
using LanguageCenter.Features.Classrooms.Queries.GetAllClassrooms;
using LanguageCenter.Features.Classrooms.Queries.GetClassroomById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassroomsController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public ClassroomsController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<ClassroomEntity> classrooms = await mediator.Send(new GetAllClassroomsQuery(), cancellationToken);
			if (classrooms == null)
				return NotFound();
			return Ok(classrooms);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			ClassroomEntity classroom = await mediator.Send(new GetClassroomByIdQuery(id), cancellationToken);
			if (classroom == null)
				return NotFound();
			return Ok(classroom);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertClassroomDto classroomDto, CancellationToken cancellationToken)
		{
			if (!await mediator.Send(new ExistsAddressByIdQuery(classroomDto.AddressId), cancellationToken))
				return NotFound();

			ClassroomEntity classroom = mapper.Map<ClassroomEntity>(classroomDto);
			await mediator.Send(new InsertClassroomCommand(classroom), cancellationToken);
			return Ok(classroom);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateClassroomDto classroomDto, CancellationToken cancellationToken)
		{
			ClassroomEntity classroom = await mediator.Send(new GetClassroomByIdQuery(id), cancellationToken);
			if (classroom == null)
				return NotFound();

			if (!await mediator.Send(new ExistsAddressByIdQuery(classroom.AddressId), cancellationToken))
				return NotFound();

			classroom = mapper.Map(classroomDto, classroom);

			await mediator.Send(new UpdateClassroomCommand(classroom), cancellationToken);
			return Ok(classroom);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteClassroomByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
