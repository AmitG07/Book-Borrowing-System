using Business_Object_Layer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class DataSeeder
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var seerviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = seerviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Users.Any())
                {
                    var users = new List<User>
                {
                new User {Name = "Ram", Username = "ram@example.com", Password = "Ram@1", Tokens_Available=5 },
                new User {Name = "Shyam", Username = "shyam@example.com", Password = "Shyam@1", Tokens_Available=5 },
                new User {Name = "Mohan", Username = "mohan@gmail.com", Password = "Mohan@1", Tokens_Available=5 },
                new User {Name = "Sohan", Username = "sohan@gmail.com", Password = "Sohan@1", Tokens_Available=5 },
                };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}
