using Microsoft.AspNetCore.Diagnostics;

namespace LanguageCenter
{
	public static class AppExtension
	{
		public static WebApplication ConfigureApp(this WebApplication app)
		{
			app.UseExceptionHandler(app =>
			{
				app.Run(async context =>
				{
					var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
					var exception = exceptionHandlerPathFeature.Error;

					await context.Response.WriteAsJsonAsync(new { error = exception.Message, statusCode = StatusCodes.Status500InternalServerError });
				});
			});

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
