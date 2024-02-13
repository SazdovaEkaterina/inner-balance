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
        throw new NotImplementedException();
    }

    public Task<Style?> GetStyleAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddStyle(Style style)
    {
        throw new NotImplementedException();
    }

    public void DeleteStyle(Style style)
    {
        throw new NotImplementedException();
    }
}