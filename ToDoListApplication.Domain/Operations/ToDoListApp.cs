using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoListApplication.Domain.Controller;
using ToDoListApplication.Domain.Repo;

namespace ToDoListApplication.Domain.Operations
{
    public class ToDoListApp
    {
        private readonly IDbDataContext db;
        public ToDoListApp()
        {
            this.db = new DbDataContext();
            db.SetContext();
        }

        public bool CreateToDoList()
        {
            var list = new ToDoList();

            Console.WriteLine("\nEnter Title of the To Do List:");
            list.Title = Console.ReadLine().Trim();

            if (db.AddList(list))
            {
                Console.WriteLine("\nToDo list Created.");
                return true;
            }

            return false;
        }

        public bool DeleteToDoList()
        {
            Console.WriteLine("\nEnter Title of the To Do List (DELETE):");
            string title = Console.ReadLine().Trim();

            Console.WriteLine("ARE YOU SURE? (sure)");
            string sure = Console.ReadLine().Trim();

            if (sure != "sure")
            {
                return false;
            }

            ToDoList item = db.ReadList(title);

            if (item is null)
            {
                Console.WriteLine("\nToDo List not found.");
                return false;
            }

            if (db.RemoveList(title))
            {
                Console.WriteLine("\nToDo List deleted.");
                return true;
            }

            Console.WriteLine("Could Not be Deleted.");
            return false;
        }

        public bool AddToDoToToDoList()
        {
            var list = GetTodoListSafe();

            if (list is null)
            {
                return false;
            }
            string todoTitle = string.Empty;

            while (todoTitle != "--exit")
            {
                Console.WriteLine("\nEnter title for Todo enty? (--exit)");
                todoTitle = Console.ReadLine().Trim();

                if (todoTitle == "--exit")
                {
                    break;
                }

                var newtodo = new ToDo() { ToDoListId = list.Id, Title = todoTitle };

                if (!db.AddToDo(newtodo))
                {
                    Console.WriteLine("Could not add Todo.");
                }
                
                Console.WriteLine("ToDo added.");
            }

            return true;
        }

        public bool DeleteTodoFromToDoList()
        {
            var todo = GetTodoSafe();

            if (todo is null)
            {
                return false;
            }

            db.RemoveToDo(todo);
            Console.WriteLine("ToDo deleted.");

            return true;
        }

        public bool SetVisibilityofToDoList()
        {
            var list = GetTodoListSafe();

            if (list is null)
            {
                return false;
            }
            Console.Write("Make Invisible? (true/false): ");
            var visibility = Console.ReadLine().Trim();

            switch (visibility)
            {
                case "true":
                    list.IsVisible = false;
                    break;
                case "false":
                    list.IsVisible = true;
                    break;
            }

            db.UpdateList(list);
            Console.WriteLine("ToDo visibility changed to: " + visibility);

            return true;
        }

        public bool SetToDoCompleted()
        {
            var todo = GetTodoSafe();

            if (todo is null)
            {
                return false;
            }

            Console.Write($"Is ToDo Completed? (true/false): ");
            var isCompleted = Console.ReadLine().Trim();

            switch (isCompleted)
            {
                case "true":
                    todo.IsCompleted = true;
                    break;
                case "false":
                    todo.IsCompleted = false;
                    break;
            }

            db.UpdateToDo(todo);
            Console.WriteLine("ToDo is completed changed to: " + isCompleted);

            return true;
        }

        public bool ModifyToDoListEntries()
        {
            var todo = GetTodoSafe();

            if (todo is null)
            {
                return false;
            }

            string decision = string.Empty;

            while (decision != "--exit")
            {
                Console.WriteLine(
                "Modify Todo (--exit)" +
                "\nTitle [1]" +
                "\nDescription [2]" +
                "\nDueDate [3]");
                decision = Console.ReadLine().Trim();

                switch (decision)
                {
                    case "1":
                        todo = SetToDoTitle(todo);
                        break;
                    case "2":
                        todo = SetToDoDesc(todo);
                        break;
                    case "3":
                        todo = SetToDoDueDate(todo);
                        break;
                }
                db.UpdateToDo(todo);
                Console.WriteLine("\nModified.");
            }

            return true;
        }

        public void GetAllToDoLists()
        {
            var list = db.ReadAllLists();

            if (list.Count <= 0)
            {
                Console.WriteLine("\nNo Todo lists");
            }

            foreach (var item in list)
            {
                if (!item.IsVisible) continue;

                Console.WriteLine();
                Console.WriteLine(item);

                Console.Write("  Get all todo's as well? (y/n): ");
                switch (Console.ReadLine().Trim())
                {
                    case "y":
                        GetAllToDos(item);
                        break;
                }
            }
        }

        private void GetAllToDos(ToDoList toDoList)
        {
            if (toDoList is null)
            {
                throw new ArgumentNullException(nameof(toDoList));
            }

            var todoList = db.ReadToDos(toDoList);

            if (todoList.Count <= 0)
            {
                Console.WriteLine("  No Todo's\n");
                return;
            }

            foreach (var item in todoList)
            {
                Console.WriteLine("\n===VVVV===");
                Console.WriteLine(item);
            }
        }

        private ToDo SetToDoDesc(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            Console.WriteLine("What is new description?");
            var desc = Console.ReadLine().Trim();

            toDo.Description = desc;

            return toDo;
        }
        private ToDo SetToDoTitle(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            Console.WriteLine("What is new title?");
            var title = Console.ReadLine().Trim();

            toDo.Title = title;

            return toDo;
        }
        private ToDo SetToDoDueDate(ToDo toDo)
        {
            if (toDo is null)
            {
                throw new ArgumentNullException(nameof(toDo));
            }

            Console.Write("When is it due to? (enter number of days from today):");
            toDo.DueDate = DateTime.Now.AddDays(int.Parse(Console.ReadLine().Trim()));

            return toDo;
        }

        private ToDo GetTodoSafe()
        {
            var todolist = GetTodoListSafe();

            Console.WriteLine("Enter ToDo's Title?");
            string todoTitle = Console.ReadLine().Trim();
            var todos = db.ReadToDos(todolist);

            if (todos.Count <= 0)
            {
                return null;
            }

            return todos.FirstOrDefault(x => x.Title == todoTitle);
        }

        private ToDoList GetTodoListSafe()
        {
            Console.WriteLine("\nEnter Title of To Do List:");
            string title = Console.ReadLine().Trim();
            var list = db.ReadList(title);

            if (list is null)
            {
                Console.WriteLine("\nToDo List not found.");
                return null;
            }

            return list;
        }
    }
}
