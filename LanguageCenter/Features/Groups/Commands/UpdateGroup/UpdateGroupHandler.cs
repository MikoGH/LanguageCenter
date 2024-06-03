using LanguageCenter.Features.Groups.Commands.UpdateGroup;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Commands.UpdateGroup
{
	public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, GroupEntity>
	{
		private readonly IGroupRepository groupRepository;
		public UpdateGroupHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<GroupEntity> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
		{
			return await groupRepository.UpdateAsync(request.group, cancellationToken);
		}
	}
}
