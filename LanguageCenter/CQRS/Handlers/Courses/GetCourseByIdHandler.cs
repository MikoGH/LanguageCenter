using LanguageCenter.CQRS.Queries.Courses;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.CQRS.Handlers.Courses
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
