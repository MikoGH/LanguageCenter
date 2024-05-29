namespace LanguageCenter
{
	public static class AppExtension
	{
		public static WebApplication ConfigureApp(this WebApplication app)
		{
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			//app.UseRouting();

			//app.UseSession();

			app.UseAuthentication();
			app.UseAuthorization();

			//app.MapRazorPages();

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
