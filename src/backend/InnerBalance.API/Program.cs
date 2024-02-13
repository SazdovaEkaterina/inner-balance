using System.Text;
using InnerBalance.API.Domain.Models;
using InnerBalance.API.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddScoped(typeof(UserManager<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
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