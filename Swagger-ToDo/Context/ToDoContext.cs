using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Swagger_ToDo.Models;

namespace Swagger_ToDo.Context
{
    public sealed class ToDoContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteModel>()
                .HasOne(p => p.User)
                .WithMany(n => n.Notes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}