using System;
using ToDoListApplication.Domain.Operations;

namespace ToDoListApplication.Client
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var list = new ToDoListApp();

            string command = string.Empty;

            while (command.Trim() != "--quit")
            {
                Console.WriteLine("\nWhat is your command? (--quit)");
                Console.WriteLine(
                     "\nCreate ToDo List [1]" +
                     "\nDelete ToDo List [2]" +
                     "\nAdd Todo to List [3]" +
                     "\nDelete Todo From List [4]" +
                     "\nSet visibility for the todo list [5]" +
                     "\nSet todo completed [6]" +
                     "\nModify todo [7]" +
                     "\nGet all todoLists [8]");

                command = Console.ReadLine().Trim();

                switch (command)
                {
                    case "1":
                        list.CreateToDoList();
                        break;
                    case "2":
                        list.DeleteToDoList();
                        break;
                    case "3":
                        list.AddToDoToToDoList();
                        break;
                    case "4":
                        list.DeleteTodoFromToDoList();
                        break;
                    case "5":
                        list.SetVisibilityofToDoList();
                        break;
                    case "6":
                        list.SetToDoCompleted();
                        break;
                    case "7":
                        list.ModifyToDoListEntries();
                        break;
                    case "8":
                        list.GetAllToDoLists();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
