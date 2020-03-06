﻿using POC.Common;
using POC.Service.Models;
using System.Data.Entity;
using System.Linq;

namespace POC.Service.Data
{
    public class TodoItemContext : DbContext
    {
        public virtual DbSet<TodoItem> Todos { get; set; }

        public virtual DbSet<UserTodoItems> UserTodoItems { get; set; }

        public static TodoItemContext Create() => new TodoItemContext();

        private TodoItemContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new TodoItemContext.Seeder());
        }

        #region OnModelConfiguring

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        #endregion

        #region Connection String

        public static string GetConnectionString()
        {
            var builder = new SqlServerConnectionStringBuilder();

            var variables = new ConnectionStringVariables(
                EnviromentConnectionStringVariable.Host(EnviromentVariables.DbHost),
                EnviromentConnectionStringVariable.Port(EnviromentVariables.DbPort),
                EnviromentConnectionStringVariable.Password(EnviromentVariables.DbPassword),
                InlineConnectionStringVariable.User("sa"),
                InlineConnectionStringVariable.DbName("TodoItemsDb"));

            var connectionString = new ConnectionStringResolver(builder, variables)
                .GetConnectionString();

            return connectionString.Value;
        }

        #endregion

        #region Seeder

        private class Seeder : CreateDatabaseIfNotExists<TodoItemContext>
        {
            protected override void Seed(TodoItemContext context)
            {
                var items1_4 = Enumerable
                    .Range(1, 4)
                    .Select(index => new TodoItem($"Task {index}"));

                var items4_8 = Enumerable
                    .Range(4, 8)
                    .Select(index => new TodoItem($"Task {index}"));

                var items8_12 = Enumerable
                    .Range(8, 12)
                    .Select(index => new TodoItem($"Task {index}"));

                var userTodoItems = new[]
                {
                    new UserTodoItems("Adam", items1_4),
                    new UserTodoItems("Adam123", items1_4),
                    new UserTodoItems("Adam0905", items1_4)
                };

                context.UserTodoItems.AddRange(userTodoItems);
            }
        }

        #endregion
    }
}