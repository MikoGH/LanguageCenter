using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.UpdateClassroom
{
	public class UpdateClassroomHandler : IRequestHandler<UpdateClassroomCommand, ClassroomEntity>
	{
		private readonly IClassroomRepository classroomRepository;
		public UpdateClassroomHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<ClassroomEntity> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
		{
			return await classroomRepository.UpdateAsync(request.classroom, cancellationToken);
		}
	}
}
