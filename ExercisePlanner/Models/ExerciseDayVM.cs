using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExercisePlanner.Model;
using System.Web.Mvc;

namespace ExercisePlanner.Models
{
    public class ExerciseDayVM
    {
        // this is what we are collecting
        public List<Exercise> Exercises { get; set; }
        
        // these are for the view
        public List<string> AreaList { get; set; }
        public Dictionary<string, List<Exercise>> ExercisesByArea { get; set; }
    }
}