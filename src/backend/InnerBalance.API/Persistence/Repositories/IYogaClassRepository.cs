using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Persistence.Repositories;

public interface IYogaClassRepository
{
    Task<IEnumerable<YogaClass>> GetYogaClassesAsync();
    Task<YogaClass?> GetYogaClassAsync(int id);
    void AddYogaClass(YogaClass yogaClass);
    void DeleteYogaClass(YogaClass yogaClass);
}