using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.Repositories;

namespace InnerBalance.API.Business.Services.Implementation;

public class YogaClassService : IYogaClassService
{
    private readonly IYogaClassRepository _yogaClassRepository;

    public YogaClassService(IYogaClassRepository yogaClassRepository)
    {
        _yogaClassRepository = yogaClassRepository;
    }

    public async Task<IEnumerable<YogaClass>> GetYogaClassesAsync()
    {
        return await _yogaClassRepository.GetYogaClassesAsync();
    }

    public async Task<YogaClass?> GetYogaClassAsync(int id)
    {
        return await _yogaClassRepository.GetYogaClassAsync(id);
    }

    public void AddYogaClass(YogaClass yogaClass)
    {
        _yogaClassRepository.AddYogaClass(yogaClass);
    }

    public  void DeleteYogaClass(YogaClass yogaClass)
    {
        _yogaClassRepository.DeleteYogaClass(yogaClass);
    }
}