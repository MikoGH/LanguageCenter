using MediatR;

namespace LanguageCenter.Features.Courses.Commands.DeleteCourseById
{
	public record DeleteCourseByIdCommand(int id) : IRequest<bool>;
}
