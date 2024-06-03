using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.GetAllAddresses
{
	public record GetAllAddressesQuery() : IRequest<IEnumerable<AddressEntity>>;
}
