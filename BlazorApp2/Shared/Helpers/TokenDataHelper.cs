using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Helpers
{
    public class TokenDataHelper
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
