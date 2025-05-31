using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DOTNETBACKEND.Models
{
    public class AppUser : IdentityUser
    {
        // Can add additional properties here if needed like risks, stocks etc.
        // By default IdentityUser has properties like Id, UserName, Email, etc.
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}