using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.InsertClassroom
{
	public class InsertClassroomHandler : IRequestHandler<InsertClassroomCommand, ClassroomEntity>
	{
		private readonly IClassroomRepository classroomRepository;
		public InsertClassroomHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<ClassroomEntity> Handle(InsertClassroomCommand request, CancellationToken cancellationToken)
		{
			return await classroomRepository.InsertAsync(request.classroom, cancellationToken);
		}
	}
}
