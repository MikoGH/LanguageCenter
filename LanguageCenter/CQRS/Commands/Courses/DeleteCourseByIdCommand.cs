using MediatR;

namespace LanguageCenter.CQRS.Commands.Courses
{
    public record DeleteCourseByIdCommand(int id) : IRequest<bool>;
}
