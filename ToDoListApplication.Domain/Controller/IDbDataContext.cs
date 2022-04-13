using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApplication.Domain.Repo;

namespace ToDoListApplication.Domain.Controller
{
    public interface IDbDataContext
    {
        public void SetContext();
        public bool AddList(ToDoList list);
        public bool RemoveList(string title);
        public bool AddToDo(ToDo toDo);
        public bool RemoveToDo(ToDo toDo);
        public bool UpdateToDo(ToDo toDo);
        public bool UpdateList(ToDoList list);
        public ToDoList ReadList(string title);
        public ICollection<ToDo> ReadToDos(ToDoList list);
        public ICollection<ToDoList> ReadAllLists();
    }
}
