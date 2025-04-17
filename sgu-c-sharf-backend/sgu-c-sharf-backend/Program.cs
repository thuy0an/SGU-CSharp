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

builder.Services.AddScoped<PhieuDatChoRepository>();
builder.Services.AddScoped<PhieuDatChoService>();

builder.Services.AddScoped<PhieuMuonRepository>();
builder.Services.AddScoped<PhieuMuonService>();

builder.Services.AddScoped<ThietBiRepository>();
builder.Services.AddScoped<ThietBiService>();

builder.Services.AddScoped<DauThietBiRepository>();
builder.Services.AddScoped<DauThietBiService>();


builder.Services.AddScoped<CheckInRepository>();
builder.Services.AddScoped<CheckInService>();

// Đăng ký MySqlConnection vào DI Container
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>();

// Cấu hình CORS cho phép truy cập từ bất kỳ nguồn nào
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Kích hoạt CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();