using POC.Channel;
using POC.Service.Contracts;
using POC.Web.AuthenticationService;
using POC.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POC.Web.Controllers
{
    public class TodoController : Controller
    {
        private ITodoService TodoService => ChannelManager.Instance
            .GetChannel<ITodoService>(new EnviromentLocatedAddress("TodoServiceUrl"));

        private IAuthenticationService AuthenticationService =>
            AuthenticationServiceFactory.GetAutheticationService(HttpContext);

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = AuthenticationService.GetUser();
            var todos = await TodoService.ListAsync(user.Username);

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
            var user = AuthenticationService.GetUser();

            await TodoService.AddAsync(model.Title, user.Username);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Complete(Guid id)
        {
            var user = AuthenticationService.GetUser();

            await TodoService.CompleteAsync(id, user.Username);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Open(Guid id)
        {
            var user = AuthenticationService.GetUser();

            await TodoService.OpenAsync(id, user.Username);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = AuthenticationService.GetUser();

            await TodoService.DeleteAsync(id, user.Username);

            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}