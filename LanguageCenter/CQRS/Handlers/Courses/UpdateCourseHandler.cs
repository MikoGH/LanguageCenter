using LanguageCenter.CQRS.Commands.Courses;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.CQRS.Handlers.Courses
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
