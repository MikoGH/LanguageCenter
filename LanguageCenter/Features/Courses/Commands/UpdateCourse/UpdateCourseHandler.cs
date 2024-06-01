using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Courses.Commands.UpdateCourse
{
	public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, CourseEntity>
	{
		private readonly ICourseRepository courseRepository;
		public UpdateCourseHandler(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}

		public async Task<CourseEntity> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
		{
			return await courseRepository.UpdateAsync(request.course, cancellationToken);
		}
	}
}
