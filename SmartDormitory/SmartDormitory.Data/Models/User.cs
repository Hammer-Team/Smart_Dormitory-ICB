﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SmartDormitory.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Sensor> Sensors { get; set; }
    }
}
