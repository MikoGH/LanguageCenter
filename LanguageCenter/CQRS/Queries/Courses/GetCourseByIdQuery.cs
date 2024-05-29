using LanguageCenter.Models.Entity;
using MediatR;

namespace LanguageCenter.CQRS.Queries.Courses
{
    public record GetCourseByIdQuery(int id) : IRequest<CourseEntity>;
}
