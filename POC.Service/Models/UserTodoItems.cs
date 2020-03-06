using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.Service.Models
{
    public class UserTodoItems
    {
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public ICollection<TodoItem> TodoItems { get; private set; }

        public UserTodoItems(string username, IEnumerable<TodoItem> todoItems) : this(username)
        {
            Id = Guid.NewGuid();

            Username = username;
            TodoItems = todoItems.ToList();
        }

        public UserTodoItems(string username)
        {
            Id = Guid.NewGuid();

            Username = username;
            TodoItems = new List<TodoItem>();
        }

        private UserTodoItems()
        {
        }

        public TodoItem AddTodo(string title)
        {
            var todo = new TodoItem(title);

            TodoItems.Add(todo);

            return todo;
        }

        public TodoItem CompleteTodo(Guid id)
        {
            var item = TodoItems.Single(todo => todo.Id == id);

            item.Complete();

            return item;
        }

        public TodoItem OpenTodo(Guid id)
        {
            var item = TodoItems.Single(todo => todo.Id == id);

            item.Open();

            return item;
        }

        public TodoItem DeleteTodo(Guid id)
        {
            var item = TodoItems.Single(todo => todo.Id == id);

            TodoItems.Remove(item);

            return item;
        }
    }
}