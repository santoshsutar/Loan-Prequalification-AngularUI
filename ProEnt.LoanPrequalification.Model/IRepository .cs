using System;
using System.Collections.Generic;

namespace ProEnt.LoanPrequalification.Model
{
    public interface IRepository<T>
    {
        void Save(T obj);
        void Add(T obj);
        T FindBy(Guid id);
        List<T> FindAll();
    }
}
