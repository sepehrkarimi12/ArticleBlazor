using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Helpers
{
    public class UserDataHelper
    {
        [Required(ErrorMessage = "ایمیل بزن")]
        [EmailAddress(ErrorMessage = "ایمیل درست بزن")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز بزن")]
        public string Password { get; set; }
    }
}
