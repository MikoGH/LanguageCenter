using LanguageCenter.Features.Groups.Queries.ExistsGroupById;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Queries.GetAllGroups
{
	public class GetAllGroupsHandler : IRequestHandler<GetAllGroupsQuery, IEnumerable<GroupEntity>>
	{
		private readonly IGroupRepository groupRepository;
		public GetAllGroupsHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<IEnumerable<GroupEntity>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
		{
			return await groupRepository.GetAllAsync(cancellationToken);
		}
	}
}
