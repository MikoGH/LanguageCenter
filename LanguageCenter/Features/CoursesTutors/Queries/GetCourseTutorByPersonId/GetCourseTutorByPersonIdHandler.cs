using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByPersonId
{
	public class GetCourseTutorByPersonIdHandler : IRequestHandler<GetCourseTutorByPersonIdQuery, IEnumerable<CourseTutorEntity>>
	{
		private readonly ICourseTutorRepository courseTutorRepository;
		public GetCourseTutorByPersonIdHandler(ICourseTutorRepository courseTutorRepository)
		{
			this.courseTutorRepository = courseTutorRepository;
		}
		public async Task<IEnumerable<CourseTutorEntity>> Handle(GetCourseTutorByPersonIdQuery request, CancellationToken cancellationToken)
		{
			return await courseTutorRepository.GetByPersonIdAsync(request.personId, cancellationToken);
		}
	}
}
