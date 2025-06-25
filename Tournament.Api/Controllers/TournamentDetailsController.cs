using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TournamentDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TournamentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDetails>>> GetTournamentDetails()
        {
            var list = await _unitOfWork.TournamentRepository.GetAllAsync();
            return Ok(list);
        }

        // GET: api/TournamentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDetails>> GetTournamentDetails(int id)
        {
            var detail = await _unitOfWork.TournamentRepository.GetByIdAsync(id);

            if (detail == null)
                return NotFound();

            return Ok(detail);
        }

        // PUT: api/TournamentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentDetails(int id, TournamentDetails tournamentDetails)
        {
            if (id != tournamentDetails.Id)
                return BadRequest();

            _unitOfWork.TournamentRepository.Update(tournamentDetails);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch
            {
                var exists = await _unitOfWork.TournamentRepository.ExistsAsync(id);
                if (!exists)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/TournamentDetails
        [HttpPost]
        public async Task<ActionResult<TournamentDetails>> PostTournamentDetails(TournamentDetails tournamentDetails)
        {
            await _unitOfWork.TournamentRepository.AddAsync(tournamentDetails);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetTournamentDetails), new { id = tournamentDetails.Id }, tournamentDetails);
        }

        // DELETE: api/TournamentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentDetails(int id)
        {
            var detail = await _unitOfWork.TournamentRepository.GetByIdAsync(id);
            if (detail == null)
                return NotFound();

            await _unitOfWork.TournamentRepository.DeleteAsync(detail);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTournamentDetails(int id, [FromBody] JsonPatchDocument<TournamentDetails> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var tournamentDetails = await _unitOfWork.TournamentRepository.GetByIdAsync(id);

            if (tournamentDetails == null)
                return NotFound();

            patchDoc.ApplyTo(tournamentDetails, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.TournamentRepository.Update(tournamentDetails);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
