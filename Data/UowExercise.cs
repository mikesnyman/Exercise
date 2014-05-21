using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExercisePlanner.Model;

namespace ExercisePlanner.Data
{
    public class UowExercise : IUnitOfWork, IDisposable
    {
        private ExerciseDbContext DbContext { get; set; }

        public UowExercise()
        {
            CreateDbContext();
        }

        //repositories
        #region Repositories
        private IRepository<Exercise> _exercises;
        private IRepository<ExerciseDay> _exerciseDays;
        private IRepository<ExercisePlan> _exercisePlans;
        private IRepository<ExerciseWeek> _exerciseWeeks;
        private IRepository<Trainer> _trainers;
        private IRepository<Client> _clients;

        public IRepository<Exercise> Exercises
        {
            get
            {
                if (_exercises == null)
                {
                    _exercises = new RepositoryGeneric<Exercise>(DbContext);
                }
                return _exercises;
            }
        }
        public IRepository<ExerciseDay> ExerciseDays
        {
            get
            {
                if (_exerciseDays == null)
                {
                    _exerciseDays = new RepositoryGeneric<ExerciseDay>(DbContext);
                }
                return _exerciseDays;
            }
        }
        public IRepository<ExerciseWeek> ExerciseWeeks
        {
            get
            {
                if (_exerciseWeeks == null)
                {
                    _exerciseWeeks = new RepositoryGeneric<ExerciseWeek>(DbContext);
                }
                return _exerciseWeeks;
            }
        }
        public IRepository<ExercisePlan> ExercisePlans
        {
            get
            {
                if (_exercisePlans == null)
                {
                    _exercisePlans = new RepositoryExercisePlan(DbContext);
                }
                return _exercisePlans;
            }
        }
        public IRepository<Trainer> Trainers
        {
            get
            {
                if (_trainers == null)
                {
                    _trainers = new RepositoryGeneric<Trainer>(DbContext);
                }
                return _trainers;
            }
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new RepositoryGeneric<Client>(DbContext);
                }
                return _clients;
            }
        }
        #endregion

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new ExerciseDbContext();

            // Do NOT enable proxied entities, else serialization fails.
            //if false it will not get the associated certification and skills when we
            //get the applicants
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
