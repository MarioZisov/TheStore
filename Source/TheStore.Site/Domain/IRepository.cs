namespace TheStore.Site.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }

        T GetById(object id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}