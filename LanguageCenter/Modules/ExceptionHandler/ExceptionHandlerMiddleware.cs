using LanguageCenter.Data;
using LanguageCenter.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace LanguageCenter.Modules.ExceptionMiddleware
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate next;
		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await httpContext.Response.WriteAsJsonAsync(new { error = ex.Message, statusCode = StatusCodes.Status500InternalServerError });
			}
		}
	}
}
