using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Commands.DeleteCourseTutor
{
	public record DeleteCourseTutorCommand(CourseTutorEntity courseTutor) : IRequest<bool>;
}
