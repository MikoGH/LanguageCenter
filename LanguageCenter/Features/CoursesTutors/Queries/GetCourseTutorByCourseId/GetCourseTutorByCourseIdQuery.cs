using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByCourseId
{
	public record GetCourseTutorByCourseIdQuery(int courseId) : IRequest<IEnumerable<CourseTutorEntity>>;
}
