using InnerBalance.API.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InnerBalance.API.Persistence.DbContext;

public class InnerBalanceDbContext : IdentityDbContext<User>
{
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Style> Styles { get; set; } = null!;
    public DbSet<YogaClass> YogaClasses { get; set; } = null!;
        
    public new DbSet<User> Users { get; set; } = null!;
    
    public InnerBalanceDbContext(DbContextOptions<InnerBalanceDbContext> options)
        :base(options)
    {
        
    }
    
}