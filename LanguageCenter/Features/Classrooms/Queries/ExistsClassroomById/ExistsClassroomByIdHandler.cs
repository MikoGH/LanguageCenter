using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.ExistsClassroomById
{
	public class ExistsClassroomByIdHandler : IRequestHandler<ExistsClassroomByIdQuery, bool>
	{
		private readonly IClassroomRepository classroomRepository;
		public ExistsClassroomByIdHandler(IClassroomRepository classroomRepository)
		{
			this.classroomRepository = classroomRepository;
		}
		public async Task<bool> Handle(ExistsClassroomByIdQuery request, CancellationToken cancellationToken)
		{
			return await classroomRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
