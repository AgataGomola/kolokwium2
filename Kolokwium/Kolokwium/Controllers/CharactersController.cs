using Kolokwium.DTOs;
using Kolokwium.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet("{characterId}")]
        public async Task<IActionResult> GetCharacterInfo(int characterId)
        {
            if (!await _characterRepository.DoesCharacterExist(characterId))
            {
                return NotFound($"Character with id: {characterId} does not exist");
            }

            var character = await _characterRepository.GetCharacterInfo(characterId);
            return Ok(character);
        }

        [HttpPost("{characterId}/backpacks")]
        public async Task<IActionResult> AddToBackpack(int characterId, List<int> itemsIds)
        {
            if (!await _characterRepository.DoesCharacterExist(characterId))
            {
                return NotFound($"Character with id: {characterId} does not exist");
            }

            if (!await _characterRepository.DoItemsExist(itemsIds))
            {
                return NotFound("One or more items do not exist in the database.");
            }

            return NotFound();
        }
    }
}