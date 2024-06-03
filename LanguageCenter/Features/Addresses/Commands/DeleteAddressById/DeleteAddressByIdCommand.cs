using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.DeleteAddressById
{
	public record DeleteAddressByIdCommand(int id) : IRequest<bool>;
}
