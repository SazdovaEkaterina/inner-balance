using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace InnerBalance.API.Persistence.Repositories.Implementation;

public class YogaClassRepository : IYogaClassRepository
{
    private readonly InnerBalanceContext _context;

    public YogaClassRepository(InnerBalanceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<YogaClass>> GetYogaClassesAsync()
    {
        return await _context.YogaClasses.ToListAsync();
    }

    public async Task<YogaClass?> GetYogaClassAsync(int id)
    {
        return await _context.YogaClasses.Where(yogaClass => yogaClass.Id == id).FirstOrDefaultAsync();
    }

    public void AddYogaClass(YogaClass yogaClass)
    {
        _context.YogaClasses.Add(yogaClass);
    }

    public void DeleteYogaClass(YogaClass yogaClass)
    {
        _context.YogaClasses.Remove(yogaClass);
    }
}