using AutoMapper;
using LanguageCenter.Features.Addresses.Commands.DeleteAddressById;
using LanguageCenter.Features.Addresses.Commands.InsertAddress;
using LanguageCenter.Features.Addresses.Commands.UpdateAddress;
using LanguageCenter.Features.Addresses.Dtos;
using LanguageCenter.Features.Addresses.Queries.GetAllAddresses;
using LanguageCenter.Features.Addresses.Queries.GetAddressById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public AddressesController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<AddressEntity> addresses = await mediator.Send(new GetAllAddressesQuery(), cancellationToken);
			if (addresses == null)
				return NotFound();
			return Ok(addresses);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			AddressEntity address = await mediator.Send(new GetAddressByIdQuery(id), cancellationToken);
			if (address == null)
				return NotFound();
			return Ok(address);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertAddressDto addressDto, CancellationToken cancellationToken)
		{
			AddressEntity address = mapper.Map<AddressEntity>(addressDto);
			await mediator.Send(new InsertAddressCommand(address), cancellationToken);
			return Ok(address);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateAddressDto addressDto, CancellationToken cancellationToken)
		{
			AddressEntity address = await mediator.Send(new GetAddressByIdQuery(id), cancellationToken);
			if (address == null)
				return NotFound();

			address = mapper.Map(addressDto, address);

			await mediator.Send(new UpdateAddressCommand(address), cancellationToken);
			return Ok(address);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteAddressByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
