using AutoMapper;
using LanguageCenter.Features.Languages.Commands.DeleteLanguageById;
using LanguageCenter.Features.Languages.Commands.InsertLanguage;
using LanguageCenter.Features.Languages.Commands.UpdateLanguage;
using LanguageCenter.Features.Languages.Dtos;
using LanguageCenter.Features.Languages.Queries.GetAllLanguages;
using LanguageCenter.Features.Languages.Queries.GetLanguageById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LanguagesController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public LanguagesController(IMapper mapper, IMediator mediator) 
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<LanguageEntity> languages = await mediator.Send(new GetAllLanguagesQuery(), cancellationToken);
			if (languages == null)
				return NotFound();
			return Ok(languages);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			LanguageEntity language = await mediator.Send(new GetLanguageByIdQuery(id), cancellationToken);
			if (language == null)
				return NotFound();
			return Ok(language);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertLanguageDto languageDto, CancellationToken cancellationToken)
		{
			LanguageEntity language = mapper.Map<LanguageEntity>(languageDto);
			await mediator.Send(new InsertLanguageCommand(language), cancellationToken);
			return Ok(language);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateLanguageDto languageDto, CancellationToken cancellationToken)
		{
			LanguageEntity language = await mediator.Send(new GetLanguageByIdQuery(id), cancellationToken);
			if (language == null)
				return NotFound();

			language = mapper.Map(languageDto, language);

			await mediator.Send(new UpdateLanguageCommand(language), cancellationToken);
			return Ok(language);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteLanguageByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
