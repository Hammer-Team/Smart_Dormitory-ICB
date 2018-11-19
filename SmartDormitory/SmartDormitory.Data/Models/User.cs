using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace SmartDormitory.Data.Data
{
    public class User : IdentityUser
    {
        public ICollection<Sensor> Sensors { get; set; }

    }
}
