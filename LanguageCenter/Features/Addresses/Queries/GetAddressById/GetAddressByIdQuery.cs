using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.GetAddressById
{
	public record GetAddressByIdQuery(int id) : IRequest<AddressEntity>;
}
