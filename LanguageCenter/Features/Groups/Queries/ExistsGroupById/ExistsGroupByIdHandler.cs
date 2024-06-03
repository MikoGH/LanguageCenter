using LanguageCenter.Features.Groups.Commands.DeleteGroupById;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Groups.Queries.ExistsGroupById
{
	public class ExistsGroupByIdHandler : IRequestHandler<ExistsGroupByIdQuery, bool>
	{
		private readonly IGroupRepository groupRepository;
		public ExistsGroupByIdHandler(IGroupRepository groupRepository)
		{
			this.groupRepository = groupRepository;
		}

		public async Task<bool> Handle(ExistsGroupByIdQuery request, CancellationToken cancellationToken)
		{
			return await groupRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
