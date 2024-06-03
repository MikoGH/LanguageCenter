using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.GetAddressById
{
	public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressEntity>
	{
		private readonly IAddressRepository addressRepository;
		public GetAddressByIdHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<AddressEntity> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
		{
			return await addressRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
