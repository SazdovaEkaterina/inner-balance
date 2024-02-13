using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Business.Services;

public interface IStyleService
{
    Task<IEnumerable<Style>> GetStylesAsync();
    Task<Style?> GetStyleAsync(int id);
    void AddStyle(Style style);
    void DeleteStyle(Style style);
}