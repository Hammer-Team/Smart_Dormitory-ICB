using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SmartDormitory.Models
{
    public class User : IdentityUser
    {
        public ICollection<Sensor> Sensors { get; set; }
    }
}
