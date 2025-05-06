using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;
using sgu_c_sharf_backend.Repositories;
using sgu_c_sharf_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Đăng ký MySqlConnection vào DI Container cho Dapper
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new MySqlConnection(connectionString);
});

// Đăng ký các Repository và Service hiện có
builder.Services.AddScoped<ThanhVienRepository>();
builder.Services.AddScoped<ThanhVienService>();
builder.Services.AddScoped<LoaiThietBiRepository>();
builder.Services.AddScoped<LoaiThietBiService>();
builder.Services.AddScoped<PhieuMuonRepository>();
builder.Services.AddScoped<PhieuMuonService>();
builder.Services.AddScoped<TrangThaiPhieuMuonRepository>();
builder.Services.AddScoped<TrangThaiPhieuMuonService>();
builder.Services.AddScoped<ChiTietPhieuMuonRepository>();
builder.Services.AddScoped<ChiTietPhieuMuonService>();
builder.Services.AddScoped<ThietBiRepository>();
builder.Services.AddScoped<ThietBiService>();
builder.Services.AddScoped<DauThietBiRepository>();
builder.Services.AddScoped<DauThietBiService>();
builder.Services.AddScoped<CheckInRepository>();
builder.Services.AddScoped<CheckInService>();
builder.Services.AddScoped<PhieuXuPhatRepository>();
builder.Services.AddScoped<PhieuXuPhatService>();

// Đăng ký OTPRepository và OTPService
builder.Services.AddScoped<IOTPRepository, OTPRepository>();
builder.Services.AddScoped<IOTPService, OTPService>();

// Đăng ký IPasswordHasher
builder.Services.AddSingleton<IPasswordHasher<object>, PasswordHasher<object>>();

// Đăng ký EmailSettings cho việc gửi email
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

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

// Model cho EmailSettings
public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; }
    public string SmtpPassword { get; set; }
    public string FromEmail { get; set; }
}