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
    public class ExerciseController : Controller
    {
        // GET: /Exercise/Add
        public ActionResult Add()
        {
            var vm = new Exercise() { Id = Guid.NewGuid() };
            return View(vm);
        }

        // POST: /Trainer/Add
        [HttpPost]
        public ActionResult Add(Exercise vm)
        {
            using (var uow = new UowExercise())
            {
                uow.Exercises.Add(vm);
                uow.Commit();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DayPlan()
        {
            using(var uow = new UowExercise()) 
            {
                ExerciseDayVM vm = new ExerciseDayVM();
                var exercises = uow.Exercises.GetAll().ToList();
                vm.AreaList = exercises.Select(a => a.Area).Distinct().ToList();
                
                vm.ExercisesByArea = new Dictionary<string, List<Exercise>>();
                foreach (var area in vm.AreaList) 
                {
                    vm.ExercisesByArea.Add(area, exercises.Where(a => a.Area == area).ToList());
                }
                return View(vm);
            }
        }

        public PartialViewResult DayPlanExercise(Guid id)
        {
            using (var uow = new UowExercise())
            {
                var exercise = uow.Exercises.Find(id);
                return PartialView("_Exercise", exercise);
            }
        }

        public ActionResult WeekPlan()
        {
            return View();
        }

    }
}
