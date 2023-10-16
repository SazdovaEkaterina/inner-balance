namespace InnerBalance.API.Persistence.Repositories;

public interface IInnerBalanceRepository
{
    Task<bool> SaveChangesAsync();
}