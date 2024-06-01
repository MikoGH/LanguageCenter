using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Courses.Commands.InsertCourse
{
	public class InsertCourseHandler : IRequestHandler<InsertCourseCommand, CourseEntity>
	{
		private readonly ICourseRepository courseRepository;
		public InsertCourseHandler(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}
		public async Task<CourseEntity> Handle(InsertCourseCommand request, CancellationToken cancellationToken)
		{
			return await courseRepository.InsertAsync(request.course, cancellationToken);

		}
	}
}
