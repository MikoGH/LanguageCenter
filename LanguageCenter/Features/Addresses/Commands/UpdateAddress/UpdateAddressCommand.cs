using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.UpdateAddress
{
	public record UpdateAddressCommand(AddressEntity address) : IRequest<AddressEntity>;
}
