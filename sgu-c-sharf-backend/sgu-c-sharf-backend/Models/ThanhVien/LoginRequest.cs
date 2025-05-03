using System.ComponentModel.DataAnnotations;

namespace sgu_c_sharf_backend.Models.ThanhVien;

public class LoginRequest
{
    public string Identifier { get; set; }
    public string MatKhau { get; set; }
}