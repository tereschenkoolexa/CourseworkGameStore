using CourseworkDataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseworkDomain.Interfaces
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);

    }
}
