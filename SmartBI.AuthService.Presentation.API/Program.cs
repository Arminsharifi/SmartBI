using Microsoft.EntityFrameworkCore;
using SmartBI.AuthService.Application.Interfaces;
using SmartBI.AuthService.Application.Services;
using SmartBI.AuthService.DAL.EfCore.Contexts;
using SmartBI.AuthService.DAL.EfCore.Interfaces;
using SmartBI.AuthService.DAL.EfCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("SmartAuth")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();