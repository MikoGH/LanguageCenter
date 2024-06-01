using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Courses.Commands.DeleteCourseById
{
	public class DeleteCourseByIdHandler : IRequestHandler<DeleteCourseByIdCommand, bool>
	{
		private readonly ICourseRepository courseRepository;
		public DeleteCourseByIdHandler(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}

		public async Task<bool> Handle(DeleteCourseByIdCommand request, CancellationToken cancellationToken)
		{
			return await courseRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
