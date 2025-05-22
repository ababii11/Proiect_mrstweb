using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;

namespace MRSTWeb.Data.Context
{
     public class DBContext : System.Data.Entity.DbContext
     {
          public DBContext() : base("name=MRSTWebDB") 
          {
          }

          public DbSet<ULoginData> Users { get; set; }
     }

     public class ApplicationDbInitializer
     {
          public static void Initialize(DBContext dbContext)
          {
               // Check if the "Admin" user exists
               var adminUser = dbContext.Users.FirstOrDefault(u => u.Role == URole.Admin);

               if (adminUser == null)
               {
                    // Create a new admin user if not found
                    var newAdminUser = new ULoginData
                    {
                         Credential = "admin@mrstweb",
                         Password = "123456",  
                         Role = URole.Admin,
                      
                    };

                    dbContext.Users.Add(newAdminUser);
                    dbContext.SaveChanges();
               }
          }
     }

}
