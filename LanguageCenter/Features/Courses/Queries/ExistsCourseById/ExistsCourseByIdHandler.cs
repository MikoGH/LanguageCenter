using LanguageCenter.Features.Courses.Queries.GetAllCourses;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Courses.Queries.ExistsCourseById
{
	public class ExistsCourseByIdHandler : IRequestHandler<ExistsCourseByIdQuery, bool>
	{
		private readonly ICourseRepository courseRepository;
		public ExistsCourseByIdHandler(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}
		public async Task<bool> Handle(ExistsCourseByIdQuery request, CancellationToken cancellationToken)
		{
			return await courseRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
