using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.Repositories;

namespace InnerBalance.API.Business.Services.Implementation;

public class StyleService : IStyleService
{
    private readonly IStyleRepository _styleRepository;

    public StyleService(IStyleRepository styleRepository)
    {
        _styleRepository = styleRepository;
    }

    public Task<IEnumerable<Style>> GetStylesAsync()
    {
        return _styleRepository.GetStylesAsync();
    }

    public Task<Style?> GetStyleAsync(int id)
    {
        return _styleRepository.GetStyleAsync(id);
    }

    public void AddStyle(Style style)
    {
        _styleRepository.AddStyle(style);
    }

    public void DeleteStyle(Style style)
    {
        _styleRepository.DeleteStyle(style);
    }
}