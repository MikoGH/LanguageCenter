using LanguageCenter.CQRS.Commands.Courses;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.CQRS.Handlers.Courses
{
    public class DeleteCourseByIdHandle : IRequestHandler<DeleteCourseByIdCommand, bool>
    {
        private readonly ICourseRepository courseRepository;
        public DeleteCourseByIdHandle(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> Handle(DeleteCourseByIdCommand request, CancellationToken cancellationToken)
        {
            return await courseRepository.DeleteByIdAsync(request.id, cancellationToken);
        }
    }
}
