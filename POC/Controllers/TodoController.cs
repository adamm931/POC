using POC.Models;
using POC.Service.Client;
using POC.Service.Constants;
using POC.Service.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoServiceAsync TodoService = ChannelBuilder<ITodoServiceAsync>
            .Create()
            .WithUrlFromEnv(EnviromentVariables.TodoServiceUrl)
            .Build();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var todos = await TodoService.ListAsync();

            var model = new TodoListViewModel
            {
                Items = todos.Select(todo => new TodoListItemViewModel
                {
                    Id = todo.Id,
                    Index = todos.FindIndex(item => item.Id == todo.Id) + 1,
                    Title = todo.Title,
                    IsComleted = todo.IsCompleted,
                    CreatedAt = todo.CreatedAt
                })
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
            await TodoService.AddAsync(model.Title);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Complete(Guid id)
        {
            await TodoService.CompleteAsync(id);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Open(Guid id)
        {
            await TodoService.OpenAsync(id);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await TodoService.DeleteAsync(id);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}