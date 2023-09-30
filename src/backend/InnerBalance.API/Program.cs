using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InnerBalanceContext>(
    optionsBuilder => optionsBuilder.UseNpgsql(
        @"User ID = postgres;
        Password=my_password;
        Server=localhost;
        Port=54320;
        Database=InnerBalanceDB;
        Integrated Security=true;
        Pooling=true"
    )
);

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<InnerBalanceContext>()
    .AddDefaultTokenProviders(); 

builder.Services.AddScoped(typeof(UserManager<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();