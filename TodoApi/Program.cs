using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Routes;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔑 Add PostgreSQL connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 💾 Register PostgreSQL instead of InMemory
builder.Services.AddDbContext<TodoDb>(options =>
    options.UseNpgsql(connectionString));

// Services
builder.Services.AddScoped<TodoService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");
// 👇 Route mapping
TodoRoutes.Register(app);

app.Run();