﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User:IdentityUser<int>
    {
        public IEnumerable<Product> Products { get; set; }
    }
}