var builder = WebApplication.CreateBuilder(args);

// Đăng ký các service (giống như @Bean bên Spring)
builder.Services.AddControllers();

var app = builder.Build();

// Thêm middleware (giống như filter trong Spring Boot)
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Tự động tìm kiếm các Controller

app.Run();