using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Helpers
{
    public class ProtectPasswordHelper
    {
        public string GetRandomSalt() => BCrypt.Net.BCrypt.GenerateSalt(12);

        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());

        public bool ValidatePassword(string password, string correctHash) => BCrypt.Net.BCrypt.Verify(password, correctHash);
    }
}
