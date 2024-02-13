using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Business.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetRoomsAsync();
    Task<Room?> GetRoomAsync(int id);
    void AddRoom(Room room);
    void DeleteRoom(Room room);
}