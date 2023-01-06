// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.MapGet("/", () => "Hello World!");
//
// app.Run();
//
//
//




// editado:
// using Microsoft.EntityFrameworkCore;
// using Manager.API.Controllers;

using AutoMapper;
using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region AutoMapperConfig
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel , UserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
#endregion


#region DI // injecoes de dependecias
builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<ManagerContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
builder.Services.AddScoped<IUserService, UserService>(); //pesquisar sobre isso
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
#endregion


// builder.Services.AddDbContext<DataContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
