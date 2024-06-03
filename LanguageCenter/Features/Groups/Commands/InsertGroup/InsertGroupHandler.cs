using LanguageCenter.Features.Groups.Commands.UpdateGroup;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Commands.InsertGroup
{
	public class InsertGroupHandler : IRequestHandler<InsertGroupCommand, GroupEntity>
	{
		private readonly IGroupRepository groupRepository;
		public InsertGroupHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<GroupEntity> Handle(InsertGroupCommand request, CancellationToken cancellationToken)
		{
			return await groupRepository.InsertAsync(request.group, cancellationToken);
		}
	}
}
