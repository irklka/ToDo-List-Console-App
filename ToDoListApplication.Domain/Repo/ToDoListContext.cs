using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApplication.Domain.Repo
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {

        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoList> toDoLists { get; set; }
        public DbSet<ToDo> toDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.; Database = ToDoListsDatabase; Trusted_Connection=True;");
            }
        }

    }
}
