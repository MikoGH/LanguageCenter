using MediatR;

namespace LanguageCenter.Features.Classrooms.Queries.ExistsClassroomById
{
	public record ExistsClassroomByIdQuery(int id) : IRequest<bool>;
}
