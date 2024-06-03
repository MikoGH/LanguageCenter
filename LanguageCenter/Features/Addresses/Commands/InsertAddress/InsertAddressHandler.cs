using LanguageCenter.Features.Addresses.Commands.DeleteAddressById;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.InsertAddress
{
	public class InsertAddressHandler : IRequestHandler<InsertAddressCommand, AddressEntity>
	{
		private readonly IAddressRepository addressRepository;
		public InsertAddressHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<AddressEntity> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
		{
			return await addressRepository.InsertAsync(request.address, cancellationToken);
		}
	}
}
