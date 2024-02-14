using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.Repositories;

namespace InnerBalance.API.Business.Services.Implementation;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public Task<IEnumerable<Room>> GetRoomsAsync()
    {
        return _roomRepository.GetRoomsAsync();
    }

    public Task<Room?> GetRoomAsync(int id)
    {
        return _roomRepository.GetRoomAsync(id);
    }

    public void AddRoom(Room room)
    {
        _roomRepository.AddRoom(room);
    }

    public void DeleteRoom(Room room)
    {
        _roomRepository.DeleteRoom(room);
    }
}