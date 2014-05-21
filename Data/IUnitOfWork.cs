using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercisePlanner.Data
{
    public interface IUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();
    }
}
