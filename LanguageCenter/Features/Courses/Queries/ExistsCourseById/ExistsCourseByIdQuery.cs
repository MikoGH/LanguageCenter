using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Courses.Queries.ExistsCourseById
{
	public record ExistsCourseByIdQuery(int id) : IRequest<bool>;
}
