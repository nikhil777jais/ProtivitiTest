using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProtivitiTest.WebAPI.Data;
using ProtivitiTest.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//using extension methods for better core maintainability.
builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
//    context.Database.OpenConnection();
//    context.Database.EnsureCreated();
//}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
