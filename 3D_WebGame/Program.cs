using _3D_WebGame.Configurations;
using _3D_WebGame.Interface;
using _3D_WebGame.Repositories;
using _3D_WebGame.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb"))
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton(provider => {
    var config = new MapperConfiguration(cfg => {
        cfg.AddProfile(new GameMappingProfile());
    });
    return config.CreateMapper();
});
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
