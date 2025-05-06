namespace sgu_c_sharf_backend.Models.ThanhVien;
public class ChangePassword
{
    public int Identifier { get; set; }
    public string MatKhauMoi { get; set; }
    public string MatKhauCu { get; set; }
}

public class ForgotPassword
{
    public int Identifier { get; set; }
    public string MatKhauMoi { get; set; }
}