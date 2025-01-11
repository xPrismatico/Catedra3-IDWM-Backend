using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra3_IDWM_Backend.src.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email);
    }
}