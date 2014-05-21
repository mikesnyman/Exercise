using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExercisePlanner.Model
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }
        public string Area { get; set; }
        public string ExerciseType { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public int DurationMinutes { get; set; }
        // link to Youtube video optional
        public Trainer Trainer { get; set; }

        [NotMapped]
        public TimeSpan Duration
        {
            get { return TimeSpan.FromMinutes(DurationMinutes); }
        }
    }
}
