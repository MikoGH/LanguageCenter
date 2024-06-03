using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Commands.InsertCourseTutor
{
	public class InsertCourseTutorHandler : IRequestHandler<InsertCourseTutorCommand, CourseTutorEntity>
	{
		private readonly ICourseTutorRepository courseTutorRepository;
		public InsertCourseTutorHandler(ICourseTutorRepository courseTutorRepository)
		{
			this.courseTutorRepository = courseTutorRepository;
		}
		public async Task<CourseTutorEntity> Handle(InsertCourseTutorCommand request, CancellationToken cancellationToken)
		{
			return await courseTutorRepository.InsertAsync(request.courseTutor, cancellationToken);
		}
	}
}
