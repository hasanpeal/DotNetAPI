using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Models;

namespace DOTNETBACKEND.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}