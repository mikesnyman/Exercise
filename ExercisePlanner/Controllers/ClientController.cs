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
    public class ClientController : Controller
    {
        // GET: /Client/Add
        public ActionResult Add()
        {
            var vm = new Client() { Id = Guid.NewGuid() };
            return View(vm);
        }

        // POST: /Client/Add
        [HttpPost]
        public ActionResult Add(Client vm)
        {
            using (var uow = new UowExercise())
            {
                uow.Clients.Add(vm);
                uow.Commit();
            }
            return RedirectToAction("Add", "Client");
        }

        // GET: /Client/Edit
        public ActionResult Edit() // cant use Client vm because same as post parameters
        {
            return View();
        }

        //Post: /Client Edit
        [HttpPost]
        public ActionResult Edit(Client vm)
        {
            using (var uow = new UowExercise())
            {
                if(/*if vm exists*/true)
                {
                    // delete and replace
                    uow.Clients.Add(vm);
                    uow.Commit();
                }
            }
            return RedirectToAction("Add", "Client");
        }

        public List<Client> Display()
        {
            List<Client> myList = new List<Client>();
            using (var uow = new UowExercise())
            {
                uow.Trainers.GetAll();
            }

            return myList;
        }

    }
}
