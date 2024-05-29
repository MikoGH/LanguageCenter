using LanguageCenter.Models.Entity;
using MediatR;

namespace LanguageCenter.CQRS.Commands.Courses
{
    public record UpdateCourseCommand(CourseEntity course) : IRequest<CourseEntity>;
}
