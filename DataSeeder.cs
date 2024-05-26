using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Implementations;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LanguageCenter
{
	public static class DataSeeder
	{
		public static void Seed(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			using var context = scope.ServiceProvider.GetRequiredService<Context>();
			context.Database.EnsureCreated();
			AddLanguages(context);
			AddLevels(context);
			AddCourses(context);
		}

		private static void AddCourses(Context context)
		{
			LanguageRepository languageRepository = new LanguageRepository(context);
			LevelRepository levelRepository = new LevelRepository(context);
			CourseRepository courseRepository = new CourseRepository(context);
			var language = languageRepository.GetAll().FirstOrDefault();
			var level = levelRepository.GetAll().FirstOrDefault();
			var course = courseRepository.GetAll().FirstOrDefault();
			//if (course != null) 
			//	courseRepository.Delete(course);
			if (level == null || language == null || course != null) return;

			courseRepository.Insert(new CourseEntity
			{
				LanguageId = language.Id,
				LevelId = level.Id,
				Count_lessons = 4
			});
		}

		private static void AddLevels(Context context)
		{
			LevelRepository levelRepository = new LevelRepository(context);
			var level = levelRepository.GetAll().FirstOrDefault();
			if (level != null) return;

			levelRepository.Insert(new LevelEntity
			{
				Name = "Intermediate"
			});
		}

		private static void AddLanguages(Context context)
		{
			LanguageRepository languageRepository = new LanguageRepository(context);
			var language = languageRepository.GetAll().FirstOrDefault();
			if (language != null) return;

			languageRepository.Insert(new LanguageEntity
			{
				Name = "English"
			});
		}
	}
}
