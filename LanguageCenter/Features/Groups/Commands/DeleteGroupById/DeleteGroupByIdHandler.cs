using LanguageCenter.Features.Groups.Commands.UpdateGroup;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Commands.DeleteGroupById
{
	public class DeleteGroupByIdHandler : IRequestHandler<DeleteGroupByIdCommand, bool>
	{
		private readonly IGroupRepository groupRepository;
		public DeleteGroupByIdHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<bool> Handle(DeleteGroupByIdCommand request, CancellationToken cancellationToken)
		{
			return await groupRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
