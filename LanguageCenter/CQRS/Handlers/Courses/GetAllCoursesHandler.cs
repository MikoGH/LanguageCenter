using LanguageCenter.CQRS.Queries.Courses;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.CQRS.Handlers.Courses
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseEntity>>
    {
        private readonly ICourseRepository courseRepository;
        public GetAllCoursesHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<IEnumerable<CourseEntity>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            return await courseRepository.GetAllAsync(cancellationToken);
        }
    }
}
