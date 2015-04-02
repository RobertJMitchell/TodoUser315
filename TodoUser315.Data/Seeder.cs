using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoUser315.Data.Model;

namespace TodoUser315.Data
{
    public static class Seeder
    {
        //Seed Users and Mock Data
        public static void Seed(TodoDbContext db)
        {
            // generic Identity code - store the users
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
            //generic identity - roles
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);
        }
    }
}
