using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ExercisePlanner.Model
{
    public class ExerciseWeek
    {
        [Key]
        public Guid Id { get; set; }
        public string FocusArea { get; set; }
        public ICollection<ExerciseDay> ExerciseDays { get; set; }
        // should have name

        public ExerciseWeek()
        {
            this.ExerciseDays = new HashSet<ExerciseDay>();
        }
    }
}
