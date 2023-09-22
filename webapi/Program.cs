using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ChatbotService>();
builder.Services.AddScoped<IChatService, ChatService>();

// Add Entity Framework DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Apply database migrations and update the schema
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();

    if (!dbContext.Chats.Any())
    {
        dbContext.Chats.Add(new Chat { DateTime = DateTime.Now, Text = "Initial message" });
        dbContext.SaveChanges();
    }
}


app.MapControllers();

app.Run();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
