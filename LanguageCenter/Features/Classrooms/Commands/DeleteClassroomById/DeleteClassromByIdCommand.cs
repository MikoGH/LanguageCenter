using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.DeleteClassroomById
{
	public record DeleteClassromByIdCommand(int id) : IRequest<bool>;
}
