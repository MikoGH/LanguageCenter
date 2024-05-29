using LanguageCenter.CQRS.Commands.Courses;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.CQRS.Handlers.Courses
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
