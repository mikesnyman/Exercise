using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ExercisePlanner.Model;

namespace ExercisePlanner.Data
{
    public class RepositoryExercisePlan: RepositoryGeneric<ExercisePlan>
    {
        public RepositoryExercisePlan(DbContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<ExercisePlan> GetAll()
        {
            return DbSet
                .Include("Trainer")
                .Include("Clients")
                .Include("ExerciseWeeks")
                .Include("ExerciseWeeks.ExerciseDays")
                .Include("ExerciseWeeks.ExerciseDays.Exercises");
        }

        public override ExercisePlan Find(params object[] keyValues)
        {
            var id = (Guid)keyValues[0];
            return GetAll().Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
