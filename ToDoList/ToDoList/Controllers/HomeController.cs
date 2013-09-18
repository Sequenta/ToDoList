using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ToDoList.DataAccess;
using ToDoList.Domain;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private RavenConnector databaseConnector;

        public HomeController()
        {
            databaseConnector = new RavenConnector(ConfigurationManager.ConnectionStrings["RavenDB"].ConnectionString);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveTask(string taskText)
        {
            var task = new Task() {Message = taskText};
            databaseConnector.Save(task);
            var jsonResult = new Dictionary<string, string>
            {
                {"id", task.Id}, 
                {"text", task.Message}
            };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}
