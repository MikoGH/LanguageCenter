using LanguageCenter.Features.Addresses.Queries.ExistsAddressById;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Addresses.Commands.DeleteAddressById
{
	public class DeleteAddressByIdHandler : IRequestHandler<DeleteAddressByIdCommand, bool>
	{
		private readonly IAddressRepository addressRepository;
		public DeleteAddressByIdHandler(IAddressRepository addressRepository)
		{
			this.addressRepository = addressRepository;
		}
		public async Task<bool> Handle(DeleteAddressByIdCommand request, CancellationToken cancellationToken)
		{
			return await addressRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
