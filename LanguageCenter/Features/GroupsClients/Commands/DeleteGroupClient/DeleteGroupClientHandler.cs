using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Commands.DeleteGroupClient
{
	public class DeleteGroupClientHandler : IRequestHandler<DeleteGroupClientCommand, bool>
	{
		private readonly IGroupClientRepository groupClientRepository;
		public DeleteGroupClientHandler(IGroupClientRepository groupClientRepository)
		{
			this.groupClientRepository = groupClientRepository;
		}
		public async Task<bool> Handle(DeleteGroupClientCommand request, CancellationToken cancellationToken)
		{
			return await groupClientRepository.DeleteAsync(request.groupClient, cancellationToken);
		}
	}
}
