using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _unitOfWork.PlayerRepository.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(id);

            if (player == null) return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            await _unitOfWork.PlayerRepository.AddAsync(player);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id) return BadRequest();

            _unitOfWork.PlayerRepository.Update(player);

            if (!await _unitOfWork.PlayerRepository.ExistsAsync(id))
                return NotFound();

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(id);
            if (player == null) return NotFound();

            await _unitOfWork.PlayerRepository.DeleteAsync(player);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
