using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ExercisePlanner.Model
{
    public class Trainer
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<ExercisePlan> ExercisePlans { get; set; }

        public Trainer()
        {
            this.ExercisePlans = new HashSet<ExercisePlan>();
            this.Clients = new HashSet<Client>();
        }
    }
}
