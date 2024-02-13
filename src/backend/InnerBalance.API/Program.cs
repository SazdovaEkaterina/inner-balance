using System.Text;
using InnerBalance.API.Business.Services;
using InnerBalance.API.Business.Services.Implementation;
using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using InnerBalance.API.Persistence.Repositories;
using InnerBalance.API.Persistence.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

builder.Services.AddDefaultIdentity<User>(
        options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<InnerBalanceContext>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (
                    Encoding.ASCII.GetBytes
                    (
                        builder.Configuration["Authentication:SecretForKey"]
                    )
                )
            };
        }
    );
builder.Services.AddScoped<IInnerBalanceRepository, InnerBalanceRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IStyleRepository, StyleRepository>();
builder.Services.AddScoped<IYogaClassRepository, YogaClassRepository>();
builder.Services.AddScoped(typeof(UserManager<>));

builder.Services.AddTransient<IInnerBalanceService, InnerBalanceService>();
builder.Services.AddTransient<IYogaClassService, YogaClassService>();

builder.Services.AddScoped(typeof(UserManager<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:4200"));

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();