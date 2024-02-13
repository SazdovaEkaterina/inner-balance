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
        throw new NotImplementedException();
    }

    public Task<Room?> GetRoomAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void AddRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public void DeleteRoom(Room room)
    {
        throw new NotImplementedException();
    }
}