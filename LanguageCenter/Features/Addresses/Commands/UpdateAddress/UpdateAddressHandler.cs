using LanguageCenter.Features.Addresses.Commands.InsertAddress;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.UpdateAddress
{
	public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, AddressEntity>
	{
		private readonly IAddressRepository addressRepository;
		public UpdateAddressHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<AddressEntity> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
		{
			return await addressRepository.UpdateAsync(request.address, cancellationToken);
		}
	}
}
