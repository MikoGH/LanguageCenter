using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.ExistsAddressById
{
	public record ExistsAddressByIdQuery(int id) : IRequest<bool>;
}
