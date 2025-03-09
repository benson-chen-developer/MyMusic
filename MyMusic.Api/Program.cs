using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyMusic.Core;
using MyMusic.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<MyMusicDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        x => x.MigrationsAssembly("MyMusic.Data")
    )
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
