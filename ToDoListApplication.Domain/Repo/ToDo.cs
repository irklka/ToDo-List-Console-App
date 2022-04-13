using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApplication.Domain.Repo
{
    public class ToDo
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime DueDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Id: {Id,-5}\nTitle: {Title,-15}\n" +
                $"Description: {Description}\nCompleted: {IsCompleted}\n" +
                $"Due Date: {DueDate.Date:dd:MM:yyyy}";
        }
    }
}
