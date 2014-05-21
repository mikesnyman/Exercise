using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ExercisePlanner.Model
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<ExercisePlan> ExercisePlans { get; set; }

        public Client()
        {
            this.ExercisePlans = new HashSet<ExercisePlan>();
        }
    }
}
