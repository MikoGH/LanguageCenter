using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Queries.GetCourseTutorByPersonId
{
	public record GetCourseTutorByPersonIdQuery(int personId) : IRequest<IEnumerable<CourseTutorEntity>>;
}
