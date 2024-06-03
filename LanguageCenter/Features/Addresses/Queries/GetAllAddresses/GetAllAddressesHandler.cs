using LanguageCenter.Features.Addresses.Queries.GetAddressById;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.GetAllAddresses
{
	public class GetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressEntity>>
	{
		private readonly IAddressRepository addressRepository;
		public GetAllAddressesHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<IEnumerable<AddressEntity>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
		{
			return await addressRepository.GetAllAsync(cancellationToken);
		}
	}
}
