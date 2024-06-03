using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByGroupId
{
	public class GetGroupClientByGroupIdHandler : IRequestHandler<GetGroupClientByGroupIdQuery, IEnumerable<GroupClientEntity>>
	{
		private readonly IGroupClientRepository groupClientRepository;
		public GetGroupClientByGroupIdHandler(IGroupClientRepository groupClientRepository)
		{
			this.groupClientRepository = groupClientRepository;
		}
		public async Task<IEnumerable<GroupClientEntity>> Handle(GetGroupClientByGroupIdQuery request, CancellationToken cancellationToken)
		{
			return await groupClientRepository.GetByGroupIdAsync(request.groupId, cancellationToken);
		}
	}
}
