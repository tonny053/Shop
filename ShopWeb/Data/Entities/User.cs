﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Data.Entities
{
    public class User:IdentityUser
    {
        public string FirsrName { get; set; }

        public string Lastname { get; set; }


    }
}
