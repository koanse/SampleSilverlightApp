
namespace StudBusApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Data.Objects;


    // Implements application logic using the dbEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class StudDomainService : LinqToEntitiesDomainService<dbEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Группа' query.
        public IQueryable<Группа> GetГруппа()
        {
            return this.ObjectContext.Группа;
        }

        public void InsertГруппа(Группа группа)
        {
            if ((группа.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(группа, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Группа.AddObject(группа);
            }
        }

        public void UpdateГруппа(Группа currentГруппа)
        {
            this.ObjectContext.Группа.AttachAsModified(currentГруппа, this.ChangeSet.GetOriginal(currentГруппа));
        }

        public void DeleteГруппа(Группа группа)
        {
            if ((группа.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Группа.Attach(группа);
            }
            this.ObjectContext.Группа.DeleteObject(группа);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Дисциплина' query.
        public IQueryable<Дисциплина> GetДисциплина()
        {
            return this.ObjectContext.Дисциплина;
        }

        public void InsertДисциплина(Дисциплина дисциплина)
        {
            if ((дисциплина.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(дисциплина, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Дисциплина.AddObject(дисциплина);
            }
        }

        public void UpdateДисциплина(Дисциплина currentДисциплина)
        {
            this.ObjectContext.Дисциплина.AttachAsModified(currentДисциплина, this.ChangeSet.GetOriginal(currentДисциплина));
        }

        public void DeleteДисциплина(Дисциплина дисциплина)
        {
            if ((дисциплина.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Дисциплина.Attach(дисциплина);
            }
            this.ObjectContext.Дисциплина.DeleteObject(дисциплина);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Оценка' query.
        public IQueryable<Оценка> GetОценка()
        {
            return this.ObjectContext.Оценка;
        }

        
        public IQueryable<Оценка> GetОценкаByГруппаДисциплина(int КодДисциплины,int КодГруппы)
        {            
            var query = from m in this.ObjectContext.Оценка
                        where m.КодДисциплины==КодДисциплины && m.Студент.КодГруппы==КодГруппы
                        select m;
            return query;
        }

        public double GetAvgОценкаByГруппаДисциплина(int КодДисциплины, int КодГруппы)
        {
            var q = from m in this.ObjectContext.Оценка
                    where m.КодДисциплины == КодДисциплины && m.Студент.КодГруппы == КодГруппы
                    select m;
            if (q.Count() > 0)
                return q.Average(m => m.Оценка1);
            return 0;
        }

        public void InsertОценка(Оценка оценка)
        {
            if ((оценка.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(оценка, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Оценка.AddObject(оценка);
            }
        }

        public void UpdateОценка(Оценка currentОценка)
        {
            this.ObjectContext.Оценка.AttachAsModified(currentОценка, this.ChangeSet.GetOriginal(currentОценка));
        }

        public void DeleteОценка(Оценка оценка)
        {
            if ((оценка.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Оценка.Attach(оценка);
            }
            this.ObjectContext.Оценка.DeleteObject(оценка);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ОценкаПодробно' query.
        public IQueryable<ОценкаПодробно> GetОценкаПодробноByГруппаДисциплина()
        {
            return this.ObjectContext.ОценкаПодробно;
        }

        public void InsertОценкаПодробно(ОценкаПодробно оценкаПодробно)
        {
            if ((оценкаПодробно.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(оценкаПодробно, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ОценкаПодробно.AddObject(оценкаПодробно);
            }
        }

        public void UpdateОценкаПодробно(ОценкаПодробно currentОценкаПодробно)
        {
            this.ObjectContext.ОценкаПодробно.AttachAsModified(currentОценкаПодробно, this.ChangeSet.GetOriginal(currentОценкаПодробно));
        }

        public void DeleteОценкаПодробно(ОценкаПодробно оценкаПодробно)
        {
            if ((оценкаПодробно.EntityState == EntityState.Detached))
            {
                this.ObjectContext.ОценкаПодробно.Attach(оценкаПодробно);
            }
            this.ObjectContext.ОценкаПодробно.DeleteObject(оценкаПодробно);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Студент' query.
        public IQueryable<Студент> GetСтудент()
        {
            return this.ObjectContext.Студент;
        }

        public IQueryable<Студент> GetСтудентГруппыБезОценокПоДисциплине(int КодГруппы, int КодДисциплины)
        {
            return from s in this.ObjectContext.Студент
                   where s.КодГруппы == КодГруппы && s.Оценка.All(m=>m.КодДисциплины!=КодДисциплины)
                   orderby s.ФИО
                   select s;
        }

        public void InsertСтудент(Студент студент)
        {
            if ((студент.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(студент, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Студент.AddObject(студент);
            }
        }

        public void UpdateСтудент(Студент currentСтудент)
        {
            this.ObjectContext.Студент.AttachAsModified(currentСтудент, this.ChangeSet.GetOriginal(currentСтудент));
        }

        public void DeleteСтудент(Студент студент)
        {
            if ((студент.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Студент.Attach(студент);
            }
            this.ObjectContext.Студент.DeleteObject(студент);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'СтудентГруппа' query.
        public IQueryable<СтудентГруппа> GetСтудентГруппа()
        {
            return this.ObjectContext.СтудентГруппа;
        }

        public void InsertСтудентГруппа(СтудентГруппа студентГруппа)
        {
            if ((студентГруппа.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(студентГруппа, EntityState.Added);
            }
            else
            {
                this.ObjectContext.СтудентГруппа.AddObject(студентГруппа);
            }
        }

        public void UpdateСтудентГруппа(СтудентГруппа currentСтудентГруппа)
        {
            this.ObjectContext.СтудентГруппа.AttachAsModified(currentСтудентГруппа, this.ChangeSet.GetOriginal(currentСтудентГруппа));
        }

        public void DeleteСтудентГруппа(СтудентГруппа студентГруппа)
        {
            if ((студентГруппа.EntityState == EntityState.Detached))
            {
                this.ObjectContext.СтудентГруппа.Attach(студентГруппа);
            }
            this.ObjectContext.СтудентГруппа.DeleteObject(студентГруппа);
        }
    }
}


