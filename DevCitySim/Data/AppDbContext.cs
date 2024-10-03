using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCitySim.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Citizen> Citizens {get; set;}
        public DbSet<Building> Buildings {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;user=root;password=;database=csd_devcitysim", ServerVersion.Parse("8.0.30")
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Citizen>()
              .HasMany(c => c.Buildings)
              .WithOne(b => b.Citizen)
              .HasForeignKey(b => b.CitizenId);

            modelBuilder.Entity<Citizen>().HasData(
                new Citizen
                {
                    Id = 1,
                    Name = "Elizabeth Grimthane",
                    DateOfBirth = new DateTime(2005, 8, 12),
                    Job = "Software Developer"
                },

                new Citizen
                {
                    Id = 2,
                    Name = "B'lu Poison",
                    DateOfBirth = new DateTime(2003, 4, 29), Job = "Professional Cutie"
                },

                new Citizen
                {
                    Id = 3,
                    Name = "Kuree Maverick",
                    DateOfBirth = new DateTime(2001, 5, 29),
                    Job = "Professional Hottie"
                },

                new Citizen
                {
                    Id = 4,
                    Name = "Charlotte Farstrider",
                    DateOfBirth = new DateTime(1991, 9, 5),
                    Job = "Professional Cuddler"
                },

                new Citizen
                {
                    Id = 5,
                    Name = "Amelia Dream",
                    DateOfBirth = new DateTime(1995, 8, 7),
                    Job = "Software Developer"
                },

                new Citizen
                {
                    Id = 6,
                    Name = "Ava Star",
                    DateOfBirth = new DateTime(1981, 11, 16),
                    Job = "Software Developer"
                },

                new Citizen
                {
                    Id = 7,
                    Name = "Sophia Blaze",
                    DateOfBirth = new DateTime(1994, 6, 16),
                    Job = "Engineer"
                },

                new Citizen
                {
                    Id = 8,
                    Name = "Mia Hawk",
                    DateOfBirth = new DateTime(2008, 5, 25),
                    Job = "Teacher"
                },

                new Citizen
                {
                    Id = 9,
                    Name = "Noah Peace",
                    DateOfBirth = new DateTime(1990, 6, 18),
                    Job = "Doctor"
                },

                new Citizen
                {
                    Id = 10,
                    Name = "Olivia Rivers",
                    DateOfBirth = new DateTime(1998, 6, 26),
                    Job = "Nurse"
                },

                new Citizen
                {
                    Id = 11,
                    Name = "Emma Hope",
                    DateOfBirth = new DateTime(1988, 9, 1),
                    Job = "Doctor"
                },

                new Citizen
                {
                    Id = 12,
                    Name = "Lucas Maverick",
                    DateOfBirth = new DateTime(2001, 1, 19),
                    Job = "Scientist"
                },

                new Citizen
                {
                    Id = 13,
                    Name = "Ethan Silver",
                    DateOfBirth = new DateTime(1994, 10, 30),
                    Job = "Teacher"
                },

                new Citizen
                {
                    Id = 14,
                    Name = "Liam Strong",
                    DateOfBirth = new DateTime(1999, 11, 11),
                    Job = "Engineer"
                },

                new Citizen
                {
                    Id = 15,
                    Name = "Sophia Blaze",
                    DateOfBirth = new DateTime(1987, 3, 21),
                    Job = "Chef"
                },

                new Citizen
                {
                    Id = 16,
                    Name = "Isabella Light",
                    DateOfBirth = new DateTime(1985, 7, 14),
                    Job = "Scientist"
                },

                new Citizen
                {
                    Id = 17,
                    Name = "Jacob Fox",
                    DateOfBirth = new DateTime(1993, 9, 23),
                    Job = "Nurse"
                },

                new Citizen
                {
                    Id = 18,
                    Name = "Daniel Iron",
                    DateOfBirth = new DateTime(1989, 10, 10),
                    Job = "Artist"
                },

                new Citizen
                {
                    Id = 19,
                    Name = "Elizabeth Bright",
                    DateOfBirth = new DateTime(2000, 4, 18),
                    Job = "Doctor"
                },

                new Citizen
                {
                    Id = 20,
                    Name = "John Light",
                    DateOfBirth = new DateTime(1983, 12, 2),
                    Job = "Software Developer"
                }
            );

            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    Name = "DevCityTech",
                    Type = "Office",
                    Location = "Nullstreet 13",
                    CitizenId = 1,
                },

                 new Building
                {
                    Id = 2,
                    Name = "Stargazer Offices",
                    Type = "Office",
                    Location = "Blustreet 1304",
                    CitizenId = 1,
                },

                new Building
                {
                    Id = 3,
                    Name = "Memory Islands",
                    Type = "Cafe",
                    Location = "Destinystreet",
                    CitizenId = 1,
                },

                new Building
                {
                    Id = 4,
                    Name = "July Care",
                    Type = "Daycare",
                    Location = "Blustreet 1306",
                    CitizenId = 2,
                },

                new Building
                {
                    Id = 5,
                    Name = "August Goodbyeport",
                    Type = "Airport",
                    Location = "Airlines 1214",
                    CitizenId = 2,
                },

                new Building
                {
                    Id = 6,
                    Name = "October Festivities",
                    Type = "House Party",
                    Location = "Airplanestreet 1710",
                    CitizenId = 2,
                }


            );
        }
    }
}
