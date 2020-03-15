using POC.Channel;
using POC.Service.Contracts;
using POC.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class TodoController : BaseController
    {
        private ITodoService TodoService => ChannelManager.Instance.GetTodoService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var todos = await TodoService.ListAsync(User.Identity.Name);

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
            await TodoService.AddAsync(model.Title, User.Identity.Name);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Complete(Guid id)
        {
            await TodoService.CompleteAsync(id, User.Identity.Name);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Open(Guid id)
        {
            await TodoService.OpenAsync(id, User.Identity.Name);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await TodoService.DeleteAsync(id, User.Identity.Name);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}