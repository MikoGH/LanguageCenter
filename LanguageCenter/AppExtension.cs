using LanguageCenter.Modules.ExceptionMiddleware;

namespace LanguageCenter
{
	public static class AppExtension
	{
		public static WebApplication ConfigureApp(this WebApplication app)
		{
			app.UseMiddleware<ExceptionHandlerMiddleware>();

			app.UseStaticFiles();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.RoutePrefix = String.Empty;
				options.DocumentTitle = "LanguageCenter Swagger";
			});

			return app;
		}
	}
}
