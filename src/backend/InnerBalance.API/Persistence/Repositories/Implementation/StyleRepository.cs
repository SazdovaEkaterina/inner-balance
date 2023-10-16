using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace InnerBalance.API.Persistence.Repositories.Implementation;

public class StyleRepository : IStyleRepository
{
    private readonly InnerBalanceContext _context;

    public StyleRepository(InnerBalanceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Style>> GetStylesAsync()
    {
        return await _context.Styles.ToListAsync();
    }

    public async Task<Style?> GetStyleAsync(int id)
    {
        return await _context.Styles.Where(style => style.Id == id).FirstOrDefaultAsync();
    }

    public void AddStyle(Style style)
    {
        _context.Styles.Add(style);
    }

    public void DeleteStyle(Style style)
    {
        _context.Styles.Remove(style);
    }
}