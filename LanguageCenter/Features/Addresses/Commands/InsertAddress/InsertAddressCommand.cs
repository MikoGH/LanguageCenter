using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.InsertAddress
{
	public record InsertAddressCommand(AddressEntity address) : IRequest<AddressEntity>;
}
