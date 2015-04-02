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

            //seed data users...
            ApplicationUser userOne = null;
            userOne = userManager.FindByName("julio@codercamps.com");
            // if USERONE does not exist, do create them
            if (userOne == null) {
                userManager.Create(new ApplicationUser {
                    Email = "julio@codercamps.com",
                    FirstName = "Julio",
                    LastName = "R",
                    UserName = "julio@codercamps.com"
                }, "123456");

                userOne = userManager.FindByName("julio@codercamps.com");
            }
            ApplicationUser userTwo = null;
            userTwo = userManager.FindByName("rickjames@codercamps.com");
            // if USERTWO does not exist, do create them
            if (userTwo == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "rickjames@codercamps.com",
                    FirstName = "Rick",
                    LastName = "James",
                    UserName = "rickjames@codercamps.com"
                }, "123456");

                userTwo = userManager.FindByName("rickjames@codercamps.com");
            }

            // if ROLES does not exist, do create them
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new Role { Name = "Admin" });
                roleManager.Create(new Role { Name = "General" });

            }
            // assign the userOne into a role
            if (!userManager.IsInRole(userOne.Id, "Admin"))
            {
                userManager.AddToRole(userOne.Id, "Admin");
            }
            // assign the userTwo into a role
            if (!userManager.IsInRole(userTwo.Id, "General"))
            {
                userManager.AddToRole(userTwo.Id, "General");
            }
            //if Todos do not exist, add them
            if (!db.Todos.Any())
            {
                db.Todos.Add(new Todo() { UserId = userOne.Id, TodoId = 1, Task = "Color Easter Eggs", DateCreated = DateTime.Now.AddDays(-10) });
                db.Todos.Add(new Todo() { UserId = userOne.Id, TodoId = 2, Task = "Eat Easter Eggs", DateCreated = DateTime.Now.AddDays(-5) });
                db.Todos.Add(new Todo() { UserId = userOne.Id, TodoId = 3, Task = "Study for Monday", DateCreated = DateTime.Now.AddDays(-1) });
                db.Todos.Add(new Todo() { UserId = userTwo.Id, TodoId = 4, Task = "Freebase on couch", DateCreated = DateTime.Now.AddDays(-1) });
                db.Todos.Add(new Todo() { UserId = userTwo.Id, TodoId = 5, Task = "Burn Couch", DateCreated = DateTime.Now.AddDays(-1) });
                db.SaveChanges();

            }

        }
    }
}
