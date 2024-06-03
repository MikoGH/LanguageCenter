using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.GetClassroomById
{
	public record GetClassroomByIdQuery(int id) : IRequest<ClassroomEntity>;
}
