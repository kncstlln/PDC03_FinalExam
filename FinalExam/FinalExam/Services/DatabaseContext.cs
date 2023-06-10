using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using FinalExam.Model;
using System.IO;

namespace FinalExam.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Animal.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}