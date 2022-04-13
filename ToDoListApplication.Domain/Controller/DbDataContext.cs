using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoListApplication.Domain.Repo;

namespace ToDoListApplication.Domain.Controller
{
    public class DbDataContext : IDbDataContext
    {
        private ToDoListContext db;

        public DbDataContext()
        {
        }

        public void SetContext()
        {
            this.db = new ToDoListContext();
        }

        public bool AddList(ToDoList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            db.Add(list);
            return db.SaveChanges() > 0;
        }

        public bool AddToDo(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            db.Add(toDo);
            return db.SaveChanges() > 0;
        }

        public ICollection<ToDoList> ReadAllLists()
        {
            return db.toDoLists.ToList();
        }

        public ToDoList ReadList(string title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            return db.toDoLists.Where(l => l.Title == title).FirstOrDefault();
        }

        public ICollection<ToDo> ReadToDos(ToDoList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return db.toDo.Where(x => x.ToDoListId == list.Id).ToList();
        }

        public bool RemoveList(string title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var list = db.toDoLists.Where(x => x.Title == title).FirstOrDefault();
            db.Remove(list);
            return db.SaveChanges() > 0;
        }

        public bool RemoveToDo(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            db.Remove(toDo);
            return db.SaveChanges() > 0;
        }

        public bool UpdateList(ToDoList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            db.Update(list);
            return db.SaveChanges() > 0;
        }

        public bool UpdateToDo(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            db.Update(toDo);
            return db.SaveChanges() > 0;
        }
    }
}
