﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoUser315.Data.Model
{
    public class Role : IdentityRole
    {
        //available roles for app/users
        public const string ADMIN = "Admin";
        public const string GENERAL = "General";
        public const string ADMIN_GENERAL = "Admin,General";
    }
}
