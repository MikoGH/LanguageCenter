using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.CoursesTutors.Commands.DeleteCourseTutor
{
	public class DeleteCourseTutorHandler : IRequestHandler<DeleteCourseTutorCommand, bool>
	{
		private readonly ICourseTutorRepository courseTutorRepository;
		public DeleteCourseTutorHandler(ICourseTutorRepository courseTutorRepository)
		{
			this.courseTutorRepository = courseTutorRepository;
		}
		public async Task<bool> Handle(DeleteCourseTutorCommand request, CancellationToken cancellationToken)
		{
			return await courseTutorRepository.DeleteAsync(request.courseTutor, cancellationToken);
		}
	}
}
