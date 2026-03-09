using EventifyAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Register DbContext for SQL Server
builder.Services.AddDbContext<EventifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ Add controllers and Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();   // needed for Swagger UI
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3️⃣ Serve static files if you have a frontend
app.UseDefaultFiles();
app.UseStaticFiles();

// 4️⃣ Use Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 5️⃣ Map controller routes
app.MapControllers();

app.Run();