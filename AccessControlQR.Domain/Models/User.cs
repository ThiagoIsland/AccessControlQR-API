using System;
using System.Collections.Generic;

namespace AcessControlQR.Domain.Models;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AccessRecord> AccessRecords { get; set; } = new List<AccessRecord>();
    
    public bool CheckPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        }

        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be empty.");
        }

        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public void ChangePassword(string oldPassword, string newPassword)
    {
        if (!CheckPassword(oldPassword))
        {
            throw new UnauthorizedAccessException("Old password is incorrect.");
        }

        SetPassword(newPassword);
    }
}
