using InnerBalance.API.Persistence.DbContext;

namespace InnerBalance.API.Persistence.Repositories.Implementation;

public class InnerBalanceRepository : IInnerBalanceRepository
{
    private readonly InnerBalanceContext _context;

    public InnerBalanceRepository(InnerBalanceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}