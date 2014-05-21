using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExercisePlanner.Data;
using ExercisePlanner.Model;
using ExercisePlanner.Models;

namespace ExercisePlanner.Controllers
{
    public class TrainerController : Controller
    {
        // GET: /Trainer/Add
        public ActionResult Add()
        {
            var vm = new Trainer() { Id = Guid.NewGuid() };
            return View(vm);
        }

        // POST: /Trainer/Add
        [HttpPost]
        public ActionResult Add(Trainer vm)
        {
            using (var uow = new UowExercise())
            {
                uow.Trainers.Add(vm);
                uow.Commit();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Trainer/Index
        public ActionResult Index(Guid id)
        {
            // list of clients (in view button to add client)
            // list of plans (in view button to create
            using (var uow = new UowExercise())
            {
                var vm = new TrainerIndexVM();
                //vm.Clients = uow.Clients.GetAll().Where(a => a.Trainer.Id == id).Select(i => new SelectListItem() { Text = i.Name, Value = i.Id.ToString() }).ToList();
                //vm.ExercisePlans = uow.ExercisePlans.GetAll().Where(a => a.Trainer.Id == id).Select(i => new SelectListItem() { Text = i.Id.ToString(), Value = i.Id.ToString() }).ToList();
                vm.Clients = uow.Clients.GetAll().Where(a => a.Trainer.Id == id).ToList();
                vm.ExercisePlans = uow.ExercisePlans.GetAll().Where(a => a.Trainer.Id == id).ToList();
                return View(vm);
            }
        }

        // GET: /Trainer/Add
        public ActionResult SendPlans()
        {
            // list of clients (in view button to add client)
            // list of plans (in view button to create
            return View();
        }

    }
}
