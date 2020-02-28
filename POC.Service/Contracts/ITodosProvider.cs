using POC.Service.Models;
using System;
using System.Collections.Generic;

namespace POC.Service.Contracts
{
    public interface ITodosProvider
    {
        TodoItem AddTodo(string name);

        TodoItem CompleteTodo(Guid guid);

        TodoItem OpenTodo(Guid guid);

        void DeleteTodo(Guid guid);

        List<TodoItem> ListTodos();
    }


}
