using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.UpdateClassroom
{
	public record UpdateClassroomCommand(ClassroomEntity classroom) : IRequest<ClassroomEntity>;
}
