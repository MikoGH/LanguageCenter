using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.GetClassroomById
{
	public class GetClassroomByIdHandler : IRequestHandler<GetClassroomByIdQuery, ClassroomEntity>
	{
		private readonly IClassroomRepository classroomRepository;
		public GetClassroomByIdHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<ClassroomEntity> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
		{
			return await classroomRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
