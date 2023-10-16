using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Persistence.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetRoomsAsync();
    Task<Room?> GetRoomAsync(int id);
    void AddRoom(Room room);
    void DeleteRoom(Room room);
}