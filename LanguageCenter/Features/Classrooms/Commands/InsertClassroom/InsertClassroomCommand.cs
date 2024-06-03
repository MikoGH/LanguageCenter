using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Commands.InsertClassroom
{
	public record InsertClassroomCommand(ClassroomEntity classroom) : IRequest<ClassroomEntity>;
}
