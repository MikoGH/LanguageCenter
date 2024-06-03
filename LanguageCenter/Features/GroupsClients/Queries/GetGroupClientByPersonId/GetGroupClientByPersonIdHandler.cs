using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByPersonId
{
	public class GetGroupClientByPersonIdHandler : IRequestHandler<GetGroupClientByPersonIdQuery, IEnumerable<GroupClientEntity>>
	{
		private readonly IGroupClientRepository groupClientRepository;
		public GetGroupClientByPersonIdHandler(IGroupClientRepository groupClientRepository)
		{
			this.groupClientRepository = groupClientRepository;
		}
		public async Task<IEnumerable<GroupClientEntity>> Handle(GetGroupClientByPersonIdQuery request, CancellationToken cancellationToken)
		{
			return await groupClientRepository.GetByGroupIdAsync(request.personId, cancellationToken);
		}
	}
}
