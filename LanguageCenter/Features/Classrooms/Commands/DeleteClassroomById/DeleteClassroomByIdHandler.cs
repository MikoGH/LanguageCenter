using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.DeleteClassroomById
{
	public class DeleteClassroomByIdHandler : IRequestHandler<DeleteClassroomByIdCommand, bool>
	{
		private readonly IClassroomRepository classroomRepository;
		public DeleteClassroomByIdHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<bool> Handle(DeleteClassroomByIdCommand request, CancellationToken cancellationToken)
		{
			return await classroomRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
