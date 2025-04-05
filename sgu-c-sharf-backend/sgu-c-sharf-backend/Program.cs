using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using sgu_c_sharf_backend.Repositories;
using sgu_c_sharf_backend.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ThanhVienRepository>();
builder.Services.AddScoped<ThanhVienService>();

builder.Services.AddScoped<LoaiThietBiRepository>();
builder.Services.AddScoped<LoaiThietBiService>(); 

// Đăng ký MySqlConnection vào DI Container
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>();

// Thêm DbContext với MySQL
// var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(
//         connectingString,
//         ServerVersion.AutoDetect(connectingString)// Kiểm tra phiên bản MySQL của bạn
//     )
// );


var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();