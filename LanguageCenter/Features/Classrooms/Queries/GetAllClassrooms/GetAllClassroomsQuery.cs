using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.GetAllClassrooms
{
	public record GetAllClassroomsQuery() : IRequest<IEnumerable<ClassroomEntity>>;
}
