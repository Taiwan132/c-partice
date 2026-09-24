var builder = WebApplication.CreateBuilder(args);

// 啟用 Controller
builder.Services.AddControllers();

var app = builder.Build();

// HTTPS Redirect
app.UseHttpsRedirection();

// 啟用 Controller 路由
app.MapControllers();

app.Run();
