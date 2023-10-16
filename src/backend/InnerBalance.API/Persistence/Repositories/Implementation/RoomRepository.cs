using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace InnerBalance.API.Persistence.Repositories.Implementation;

public class RoomRepository : IRoomRepository
{
    private readonly InnerBalanceContext _context;

    public RoomRepository(InnerBalanceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Room>> GetRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetRoomAsync(int id)
    {
        return await _context.Rooms.Where(room => room.Id == id).FirstOrDefaultAsync();
    }

    public void AddRoom(Room room)
    {
        _context.Rooms.Add(room);
    }

    public void DeleteRoom(Room room)
    {
        _context.Rooms.Remove(room);
    }
}