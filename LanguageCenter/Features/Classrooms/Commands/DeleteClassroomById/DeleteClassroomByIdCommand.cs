using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.DeleteClassroomById
{
	public record DeleteClassroomByIdCommand(int id) : IRequest<bool>;
}
