using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercisePlanner.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Find(params object[] keyValues);
        T FindQuick(params object[] keyValues);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(params object[] keyValues);
    }   
}
