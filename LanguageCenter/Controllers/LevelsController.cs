using AutoMapper;
using LanguageCenter.Features.Levels.Commands.DeleteLevelById;
using LanguageCenter.Features.Levels.Commands.InsertLevel;
using LanguageCenter.Features.Levels.Commands.UpdateLevel;
using LanguageCenter.Features.Levels.Dtos;
using LanguageCenter.Features.Levels.Queries.GetAllLevels;
using LanguageCenter.Features.Levels.Queries.GetLevelById;
using LanguageCenter.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageCenter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LevelsController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IMediator mediator;
		public LevelsController(IMapper mapper, IMediator mediator)
		{
			this.mapper = mapper;
			this.mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
		{
			IEnumerable<LevelEntity> levels = await mediator.Send(new GetAllLevelsQuery(), cancellationToken);
			if (levels == null)
				return NotFound();
			return Ok(levels);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
		{
			LevelEntity level = await mediator.Send(new GetLevelByIdQuery(id), cancellationToken);
			if (level == null)
				return NotFound();
			return Ok(level);
		}

		[HttpPost("")]
		public async Task<IActionResult> Create(InsertLevelDto levelDto, CancellationToken cancellationToken)
		{
			LevelEntity level = mapper.Map<LevelEntity>(levelDto);
			await mediator.Send(new InsertLevelCommand(level), cancellationToken);
			return Ok(level);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Update([FromRoute] int id, UpdateLevelDto levelDto, CancellationToken cancellationToken)
		{
			LevelEntity level = await mediator.Send(new GetLevelByIdQuery(id), cancellationToken);
			if (level == null)
				return NotFound();

			level = mapper.Map(levelDto, level);

			await mediator.Send(new UpdateLevelCommand(level), cancellationToken);
			return Ok(level);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		{
			bool result = await mediator.Send(new DeleteLevelByIdCommand(id), cancellationToken);
			if (!result) return NotFound();
			return Ok();
		}
	}
}
