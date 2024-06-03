using LanguageCenter.Features.Addresses.Queries.GetAddressById;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Queries.ExistsAddressById
{
	public class ExistsAddressByIdHandler : IRequestHandler<ExistsAddressByIdQuery, bool>
	{
		private readonly IAddressRepository addressRepository;
		public ExistsAddressByIdHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<bool> Handle(ExistsAddressByIdQuery request, CancellationToken cancellationToken)
		{
			return await addressRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
