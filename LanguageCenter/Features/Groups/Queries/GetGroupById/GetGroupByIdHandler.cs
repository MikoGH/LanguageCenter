using LanguageCenter.Features.Groups.Queries.GetAllGroups;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Queries.GetGroupById
{
	public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GroupEntity>
	{
		private readonly IGroupRepository groupRepository;
		public GetGroupByIdHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<GroupEntity> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
		{
			return await groupRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
