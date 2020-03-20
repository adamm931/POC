using POC.Accounts.Service.Contracts;
using POC.Configuration.Mapping;
using POC.Identity.Service.Contracts;
using POC.Identity.Web.AuthenticationService.Contracts;
using POC.Todos.Service.Contracts;
using POC.Todos.Service.UseCases.AddTodo;
using POC.Todos.Service.UseCases.CompleteTodo;
using POC.Todos.Service.UseCases.DeleteTodo;
using POC.Todos.Service.UseCases.ListTodos;
using POC.Todos.Service.UseCases.OpenTodo;
using POC.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class TodoController : BaseController
    {
        public TodoController(
            IAccountService accountService,
            IIdentityService identityService,
            ITodoService todoService,
            IAuthenticationService authenticationService,
            IMapping mapper) : base(accountService, identityService, todoService, authenticationService, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var todos = await TodoService.ListAsync(new ListTodosServiceRequest
            {
                Username = Username
            });

            var model = new TodoListViewModel
            {
                Items = Mapper.Map<IEnumerable<TodoListItemViewModel>>(todos)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddTodoViewModel model)
        {
            await TodoService.AddAsync(new AddTodoServiceRequest
            {
                Title = model.Title,
                Username = Username
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Complete(Guid id)
        {
            await TodoService.CompleteAsync(new CompleteTodoServiceRequest
            {
                Username = Username,
                Id = id
            });

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Open(Guid id)
        {
            await TodoService.OpenAsync(new OpenTodoServiceRequest
            {
                Username = Username,
                Id = id
            });

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await TodoService.DeleteAsync(new DeleteTodoServiceRequest
            {
                Username = Username,
                Id = id
            });

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}