using FPTBussiness.BOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BOs
{
    public class FPTBusinessContext : DbContext
    {
        public FPTBusinessContext()
        {
        }

        public FPTBusinessContext(DbContextOptions<FPTBusinessContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectDetails> ProjectDetails { get; set; }

        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }    



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("FPTBusiness"));
            }
        }

        string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            return config["ConnectionStrings:FPTBusiness"];
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed data for Item
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectID = 1, NameProject = "Library System" },
                   new Project { ProjectID = 2, NameProject = "Travel Website" },
                        new Project { ProjectID = 3, NameProject = "Fashion Website" }


            );

            // Seed data for ShopItem
            modelBuilder.Entity<ProjectDetails>().HasData(
                new ProjectDetails { ProjectID = 1, StaffID = 1, NumberOfHours = 120,  RoleStaff = "Manager", ProjectDetailID =1},
                  new ProjectDetails { ProjectID = 2, StaffID = 7, NumberOfHours = 100, RoleStaff = "Developer", ProjectDetailID = 2 },
                    new ProjectDetails { ProjectID = 3, StaffID = 8, NumberOfHours = 80, RoleStaff = "Design", ProjectDetailID = 3 }


            );

            // Seed data for PawnContract
            modelBuilder.Entity<Staff>().HasData(
            new Staff { StaffID = 1, FirstName = "Nguyen", LastName = "An", AddressStaff = "15 Quang Trung Da Nang", Gender = "Male", AccountID =2 },
            new Staff { StaffID = 2, FirstName = "Le", LastName = "Bao", AddressStaff = "25 Hoang Tieu Da Nang", Gender = "FeMale", AccountID = 3 },

            new Staff { StaffID = 3, FirstName = "Tran", LastName = "Cuong", AddressStaff = "30 Le Duan Da Nang", Gender = "FeMale", AccountID = 4 }



            );


            // Seed data for User
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { AccountID = 1, UserName = "admin", Password = "admin", Role = 1 },
                new UserAccount { AccountID = 2, UserName = "user1", Password = "user1", Role = 0 }

            );
        }
    }
}
