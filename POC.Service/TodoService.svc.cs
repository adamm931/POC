using POC.Service.Contracts;
using POC.Service.Data;
using POC.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Service
{
    public class TodoService : ITodoServiceAsync
    {
        private readonly ITodosProvider TodosProvider = TodosProviderResolver.GetProvider();
        private readonly ITodosAsyncProvider TodosAsyncProvider = TodosProviderResolver.GetAsyncProvider();

        //public TodoItem Add(string name)
        //{
        //    return TodosProvider.AddTodo(name);
        //}

        public async Task<TodoItem> AddAsync(string name)
        {
            return await TodosAsyncProvider.AddTodoAsync(name);
        }

        //public TodoItem Complete(Guid guid)
        //{
        //    return TodosProvider.CompleteTodo(guid);
        //}

        public async Task<TodoItem> CompleteAsync(Guid guid)
        {
            return await TodosAsyncProvider.CompleteTodoAsync(guid);
        }

        //public void Delete(Guid guid)
        //{
        //    TodosProvider.DeleteTodo(guid);
        //}

        public async Task DeleteAsync(Guid guid)
        {
            await TodosAsyncProvider.DeleteTodoAsync(guid);
        }

        //public List<TodoItem> List()
        //{
        //    return TodosProvider.ListTodos();
        //}

        public async Task<List<TodoItem>> ListAsync()
        {
            return await TodosAsyncProvider.ListTodosAsync();
        }

        //public TodoItem Open(Guid guid)
        //{
        //    return TodosProvider.OpenTodo(guid);
        //}

        public async Task<TodoItem> OpenAsync(Guid guid)
        {
            return await TodosAsyncProvider.OpenTodoAsync(guid);

        }
    }
}
