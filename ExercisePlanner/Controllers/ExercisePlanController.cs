using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExercisePlanner.Data;

namespace ExercisePlanner.Controllers
{
    public class ExercisePlanController : Controller
    {
        //
        // GET: /ExercisePlan/

        public ActionResult Index()//Guid id
        {
            /*using (var uow = new UowExercise())
            {
                var plans = uow.ExercisePlans.GetAll().Where(p => p.Trainer.Id == id).ToList();
                return View(plans);
            }*/
            return View();
        }

    }
}
