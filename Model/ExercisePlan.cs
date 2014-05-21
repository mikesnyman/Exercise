using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ExercisePlanner.Model
{
    public class ExercisePlan
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Trainer Trainer { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<ExerciseWeek> ExerciseWeeks { get; set; }
        // should have name if we sort/save by plan

        public ExercisePlan()
        {
            this.ExerciseWeeks = new HashSet<ExerciseWeek>();
            this.Clients = new HashSet<Client>();
        }
    }
}
