using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Courses.Commands.InsertCourse
{
	public record InsertCourseCommand(CourseEntity course) : IRequest<CourseEntity>;
}
