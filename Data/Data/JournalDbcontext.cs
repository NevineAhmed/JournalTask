using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
   public class JournalDbcontext: IdentityDbContext<ApplicationUser>
    {
       
        public JournalDbcontext(DbContextOptions<JournalDbcontext> options) :base(options){
            
        }
       
        
        public virtual List<Article> Articles { get; set; }
        public DbSet<ApplicationUser> users { get; set; }
        
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ApplicationUser admin = new ApplicationUser
            //{
            //    Email = "samir@devsquads.com",
            //    EmailConfirmed = true,
            //    UserName = "Admin",
            //};

            //PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            //admin.PasswordHash = ph.HashPassword(admin, "Your-PW1");

            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            //    new IdentityRole { Name = "User", NormalizedName = "User" }
            //);
            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    admin
            //);

            
         modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    id = 1,
                    title = "Article1",
                    author_name="Samir",
                    publish_time=DateTime.Now.ToString(),
                    description="fffoooooooooooooooooooooooooooooooooooooooooooooooooo",
                    published=false
                   

                },
                new Article
                {
                    id = 2,
                    title = "Article2",
                    author_name = "Yehia",
                    publish_time = DateTime.Now.ToString(),
                    description = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn",
                    published = true


                }) ;
            

        }


    }



    public class ApplicationUser : IdentityUser
    {
        public int NoOfPublishes { set; get; }
        public List<Article> articles { get; set; }

    }


    }
