using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Persistence.Repositories;

public interface IStyleRepository
{
    Task<IEnumerable<Style>> GetStylesAsync();
    Task<Style?> GetStyleAsync(int id);
    void AddStyle(Style style);
    void DeleteStyle(Style style);
}