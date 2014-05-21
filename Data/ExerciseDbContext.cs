using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ExercisePlanner.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExercisePlanner.Data
{
    public class ExerciseContextDbInitializer : DropCreateDatabaseIfModelChanges<ExerciseDbContext>
    //public class ExerciseContextDbInitializer : DropCreateDatabaseAlways<ExerciseDbContext>
    {
        protected override void Seed(ExerciseDbContext context)
        {
            var defaultTrainer = new Trainer() { Id = Guid.Parse("00000000-0000-0000-0000-000000000000"), Name = "Default Trainer" };
            
            context.Trainers.Add(defaultTrainer);

            var backExercise = new Exercise() { Id = Guid.NewGuid(), Trainer = defaultTrainer, Area = "Back" };
            var chestExercise = new Exercise() { Id = Guid.NewGuid(), Trainer = defaultTrainer, Area = "Chest" };
            context.Exercises.Add(backExercise);
            context.Exercises.Add(chestExercise);

            var trainer = new Trainer() { Id = Guid.NewGuid(), Age = 1, Email = "mikesnyman@gmail.com", Gender = "Male", Name = "Michael Nyman" };
            context.Trainers.Add(trainer);
            var client = new Client() { Id = Guid.NewGuid(), Age = 32, Gender = "Female", Name = "Lindsay N", Trainer = trainer};
            context.Clients.Add(client);
            var client2 = new Client() { Id = Guid.NewGuid(), Age = 32, Gender = "Male", Name = "Jason E", Trainer = trainer };
            context.Clients.Add(client2);

            var exercisePlan = new ExercisePlan()
            {
                Id = Guid.NewGuid(),
                Name = "Test Plan",
                Trainer = trainer,
                Clients = new List<Client>() { client, client2 },
                ExerciseWeeks = new List<ExerciseWeek>()
                {
                    new ExerciseWeek() {
                        Id = Guid.NewGuid(),
                        FocusArea = "Cardio",
                        ExerciseDays = new List<ExerciseDay>() {
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            }
                        }
                    },
                    new ExerciseWeek() {
                        Id = Guid.NewGuid(),
                        FocusArea = "Strength",
                        ExerciseDays = new List<ExerciseDay>() {
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            }
                        }
                    },
                    new ExerciseWeek() {
                        Id = Guid.NewGuid(),
                        FocusArea = "Cardio 2",
                        ExerciseDays = new List<ExerciseDay>() {
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            }
                        }
                    },
                    new ExerciseWeek() {
                        Id = Guid.NewGuid(),
                        FocusArea = "Strength 2",
                        ExerciseDays = new List<ExerciseDay>() {
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            },
                            new ExerciseDay() {
                                Id = Guid.NewGuid(),
                                Exercises = new List<Exercise>() {
                                    backExercise,
                                    chestExercise
                                }
                            }
                        }
                    }
                }
            };
            context.ExercisePlans.Add(exercisePlan);
        }
    } 

    public partial class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext()
            : base("Name=exercisePlanner")//this is the connection string name
        {
            Database.SetInitializer<ExerciseDbContext>(new ExerciseContextDbInitializer());
            //base.Database.Initialize(true);
            base.Database.Initialize(force: true);
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseDay> ExerciseDays { get; set; }
        public DbSet<ExerciseWeek> ExerciseWeeks { get; set; }
        public DbSet<ExercisePlan> ExercisePlans { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ExerciseConfig());
            modelBuilder.Configurations.Add(new ExerciseDayConfig());
            modelBuilder.Configurations.Add(new ExerciseWeekConfig());
            modelBuilder.Configurations.Add(new ExercisePlanConfig());
            modelBuilder.Configurations.Add(new TrainerConfig());
            modelBuilder.Configurations.Add(new ClientConfig());

            base.OnModelCreating(modelBuilder);
        }

        public class ExerciseConfig : EntityTypeConfiguration<Exercise>
        {
            public ExerciseConfig()
            {
                this.HasOptional(a => a.Trainer).WithMany();
            }
        }

        public class ExerciseDayConfig : EntityTypeConfiguration<ExerciseDay>
        {
            public ExerciseDayConfig()
            {
                this.HasMany(a => a.Exercises).WithMany();
            }
        }

        public class ExerciseWeekConfig : EntityTypeConfiguration<ExerciseWeek>
        {
            public ExerciseWeekConfig()
            {
                this.HasMany(a => a.ExerciseDays).WithMany();
            }
        }

        public class ExercisePlanConfig : EntityTypeConfiguration<ExercisePlan>
        {
            public ExercisePlanConfig()
            {
                this.HasMany(a => a.ExerciseWeeks).WithMany();
                this.HasMany(a => a.Clients).WithMany(b => b.ExercisePlans);
                this.HasOptional(a => a.Trainer).WithMany();
            }
        }

        public class TrainerConfig : EntityTypeConfiguration<Trainer>
        {
            public TrainerConfig()
            {
                this.HasMany(a => a.ExercisePlans).WithOptional();
                this.HasMany(a => a.Clients).WithOptional();
            }
        }

        public class ClientConfig : EntityTypeConfiguration<Client>
        {
            public ClientConfig()
            {
                this.HasOptional(a => a.Trainer).WithMany();
                this.HasMany(a => a.ExercisePlans).WithMany(b => b.Clients);
            }
        }
    }
}
