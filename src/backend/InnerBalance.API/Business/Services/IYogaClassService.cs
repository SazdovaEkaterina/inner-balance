
using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Business.Services;

public interface IYogaClassService
{ 
    Task<IEnumerable<YogaClass>> GetYogaClassesAsync();

    Task<YogaClass?> GetYogaClassAsync(int id);

    void AddYogaClass(YogaClass yogaClass);

    void DeleteYogaClass(YogaClass yogaClass);
}