using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.DeleteClassroomById
{
	public class DeleteClassromByIdHandler : IRequestHandler<DeleteClassromByIdCommand, bool>
	{
		private readonly IClassroomRepository classroomRepository;
		public DeleteClassromByIdHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<bool> Handle(DeleteClassromByIdCommand request, CancellationToken cancellationToken)
		{
			return await classroomRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
