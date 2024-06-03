using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Commands.InsertGroupClient
{
	public class InsertGroupClientHandler : IRequestHandler<InsertGroupClientCommand, GroupClientEntity>
	{
		private readonly IGroupClientRepository groupClientRepository;
		public InsertGroupClientHandler(IGroupClientRepository groupClientRepository)
		{
			this.groupClientRepository = groupClientRepository;
		}
		public async Task<GroupClientEntity> Handle(InsertGroupClientCommand request, CancellationToken cancellationToken)
		{
			return await groupClientRepository.InsertAsync(request.groupClient, cancellationToken);
		}
	}
}
