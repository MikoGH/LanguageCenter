using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Commands.InsertCourseTutor
{
	public record InsertCourseTutorCommand(CourseTutorEntity courseTutor) : IRequest<CourseTutorEntity>;
}
