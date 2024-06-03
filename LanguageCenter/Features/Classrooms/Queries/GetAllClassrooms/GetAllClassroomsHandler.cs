using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.GetAllClassrooms
{
	public class GetAllClassroomsHandler : IRequestHandler<GetAllClassroomsQuery, IEnumerable<ClassroomEntity>>
	{
		private readonly IClassroomRepository classroomRepository;
		public GetAllClassroomsHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<IEnumerable<ClassroomEntity>> Handle(GetAllClassroomsQuery request, CancellationToken cancellationToken)
		{
			return await classroomRepository.GetAllAsync(cancellationToken);
		}
	}
}
