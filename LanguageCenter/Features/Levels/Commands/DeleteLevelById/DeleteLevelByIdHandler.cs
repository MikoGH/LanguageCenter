using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Commands.DeleteLevelById
{
	public class DeleteLevelByIdHandler : IRequestHandler<DeleteLevelByIdCommand, bool>
	{
		private readonly ILevelRepository levelRepository;
		public DeleteLevelByIdHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<bool> Handle(DeleteLevelByIdCommand request, CancellationToken cancellationToken)
		{
			return await levelRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
