using Kolokwium.Context;
using Kolokwium.DTOs;
using Kolokwium.Models;

namespace Kolokwium.Repositories;

public interface ICharacterRepository
{
  Task<bool> DoesCharacterExist(int id);
  public Task<CharacterDTO> GetCharacterInfo(int id);
  public Task<bool> DoItemsExist(List<int> itemIds);

}