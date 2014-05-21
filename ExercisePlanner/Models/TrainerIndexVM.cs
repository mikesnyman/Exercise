using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExercisePlanner.Model;
using System.Web.Mvc;

namespace ExercisePlanner.Models
{
    public class TrainerIndexVM
    {
        public List<Client> Clients { get; set; }
        public List<ExercisePlan> ExercisePlans { get; set; }
    }
}