using System;
using System.Collections.Generic;
using NHibernate;
using ProEnt.LoanPrequalification.Model;

namespace ProEnt.LoanPrequalification.Repositories.NHibernate
{
    public abstract class BaseRepository<T> : IRepository<T>
    {    
        public void  Save(T obj)
        {
 	         using (ITransaction transaction = SessionProvider.GetCurrentSession().BeginTransaction())
 	         {
 	             SessionProvider.GetCurrentSession().SaveOrUpdate(obj);

 	             try
 	             {  transaction.Commit();   }
 	             catch (Exception)
 	             {
 	                 transaction.Rollback();
 	                 throw;
 	             }              
 	         }                            
        }

        public void  Add(T obj)
        {
            using (ITransaction transaction = SessionProvider.GetCurrentSession().BeginTransaction())
            {
                SessionProvider.GetCurrentSession().Save(obj);

                try
                { transaction.Commit(); }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }     
        }

        public T  FindBy(Guid id)
        {
            return SessionProvider.GetCurrentSession().Get<T>(id);
        }

        public List<T>  FindAll()
        {
            ICriteria CriteriaQuery = SessionProvider.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)CriteriaQuery.List<T>();
        }
    }
}
