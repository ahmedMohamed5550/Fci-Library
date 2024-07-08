using crud_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace crud_project.Data
{
    public class libraryDbContext : DbContext
    {
        public libraryDbContext(DbContextOptions<libraryDbContext> options) : base(options) { }

        public DbSet<author> Authors { get; set; }
        public DbSet<bookauthor> Bookauthors { get; set; }
        public DbSet<admin> Admins { get; set; }
        public DbSet<report> Reports { get; set; }
        public DbSet<borrow> Borrows { get; set; }
        public DbSet<book> Books { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace the connection string with your actual SQL Server connection string
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=libraryabo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }



}
