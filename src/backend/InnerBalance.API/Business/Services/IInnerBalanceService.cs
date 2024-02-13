namespace InnerBalance.API.Business.Services;

public interface IInnerBalanceService
{
    Task<bool> SaveChangesAsync();
}