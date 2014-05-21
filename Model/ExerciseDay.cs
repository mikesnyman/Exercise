using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ExercisePlanner.Model
{
    public class ExerciseDay
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public ExerciseDay()
        {
            this.Exercises = new HashSet<Exercise>();
        }
    }
}
