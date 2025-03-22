namespace sgu_c_sharf_backend.Services;

using Microsoft.AspNetCore.Identity;

public class PasswordService
{
    private readonly IPasswordHasher<object> _passwordHasher;

    public PasswordService(IPasswordHasher<object> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        return _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword) == PasswordVerificationResult.Success;
    }
}
