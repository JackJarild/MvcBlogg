using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC_Blogg_v2.Models
{
    public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "School", CategoryId = 1},
                new Category { Name = "Technology", CategoryId = 2},
                new Category { Name = "Food", CategoryId =  3}
            };

            categories.ForEach(c => context.Categories.Add(c));

            var posts = new List<Post>
            {
                new Post()
                {
                    Author = "Jack Järild",
                    CategoryId = 1,
                    Content =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vel tincidunt arcu. In hac habitasse platea dictumst. Cras eget risus facilisis nunc ullamcorper posuere vel sit amet ex. Aliquam augue quam, lobortis vel tellus a, feugiat posuere nisi. Nunc dui nulla, mollis nec massa in, dapibus dapibus metus. Pellentesque diam arcu, tempus in condimentum sed, ultrices sit amet odio. Cras volutpat bibendum mauris ac malesuada. Maecenas vel congue mauris. Morbi fermentum nisi non laoreet tincidunt. Aliquam finibus pellentesque tellus, sit amet iaculis arcu rutrum rutrum. Cras ligula neque, vehicula in fringilla quis, hendrerit in augue."
                        +
                        "Nunc ac felis justo. Fusce aliquam a erat vel euismod. Nullam scelerisque pharetra justo eu venenatis. Sed sollicitudin convallis porttitor. Mauris fermentum ante a quam vulputate, vel semper justo consequat. Curabitur in lacinia justo. Nunc ultricies faucibus urna quis vestibulum. Suspendisse eget metus non augue vulputate aliquam. Fusce feugiat mi arcu, eleifend semper dolor cursus a. Curabitur congue consectetur sollicitudin.",
                    DateCreated = DateTime.Now,
                    ShortDescription = "Lorem ipsum",
                    Title = "Lorem Ipsum",
                    PostId = 1        
                }
            };

            posts.ForEach(p => context.Posts.Add(p));

            context.SaveChanges();

            InitializeIdentityForEF(context);
            base.Seed(context);
            
        }

        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}