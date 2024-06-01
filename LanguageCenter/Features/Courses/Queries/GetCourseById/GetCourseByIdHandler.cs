using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Courses.Queries.GetCourseById
{
	public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseEntity>
	{
		private readonly ICourseRepository courseRepository;
		public GetCourseByIdHandler(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}
		public async Task<CourseEntity> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
		{
			return await courseRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
