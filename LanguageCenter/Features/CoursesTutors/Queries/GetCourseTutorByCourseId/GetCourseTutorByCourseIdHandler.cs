using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByCourseId
{
	public class GetCourseTutorByCourseIdHandler : IRequestHandler<GetCourseTutorByCourseIdQuery, IEnumerable<CourseTutorEntity>>
	{
		private readonly ICourseTutorRepository courseTutorRepository;
		public GetCourseTutorByCourseIdHandler(ICourseTutorRepository courseTutorRepository)
		{
			this.courseTutorRepository = courseTutorRepository;
		}
		public async Task<IEnumerable<CourseTutorEntity>> Handle(GetCourseTutorByCourseIdQuery request, CancellationToken cancellationToken)
		{
			return await courseTutorRepository.GetByCourseIdAsync(request.courseId, cancellationToken);
		}
	}
}
