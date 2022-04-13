using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApplication.Domain.Repo;

namespace ToDoListApplication.Domain.Repo
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsVisible { get; set; } = true;
        public ICollection<ToDo> ToDos { get; set; }

        public override string ToString()
        {
            return $"Id: {Id,-5}\nTitle: {Title,-15}\nIsVisible: {IsVisible}";
        }
    }
}
