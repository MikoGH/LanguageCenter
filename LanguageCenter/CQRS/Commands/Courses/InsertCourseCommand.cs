using LanguageCenter.Models.Entity;
using MediatR;

namespace LanguageCenter.CQRS.Commands.Courses
{
    public record InsertCourseCommand(CourseEntity course) : IRequest<CourseEntity>;
}
