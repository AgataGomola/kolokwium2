using Kolokwium.Context;
using Kolokwium.DTOs;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly DatabaseContext _context;
    public CharacterRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<bool> DoesCharacterExist(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CharacterDTO> GetCharacterInfo(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitlesCollection)
            .ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return new CharacterDTO()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new ItemDTO
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitlesCollection.Select(ct => new TitleDTO
            {
                Title = ct.Title.Name,
                AquiredAt = ct.AcquiredAt
            }).ToList()
        };
        }

    public Task<bool> DoItemsExist(List<int> itemIds)
    {
        throw new NotImplementedException();
    }
}
