using InnerBalance.API.Persistence.Repositories;

namespace InnerBalance.API.Business.Services.Implementation;

public class InnerBalanceService : IInnerBalanceService
{
    private readonly IInnerBalanceRepository _innerBalanceRepository;

    public InnerBalanceService(IInnerBalanceRepository innerBalanceRepository)
    {
        _innerBalanceRepository = innerBalanceRepository;
    }

    public Task<bool> SaveChangesAsync()
    {
        return _innerBalanceRepository.SaveChangesAsync();
    }
}