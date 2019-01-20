namespace TheStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using TheStore.Core.Domain;
    using TheStore.Core.Data;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext context;
        private IDbSet<T> entities;

        public Repository(IDbContext context)
        {
            this.context = context; 
        }

        public IQueryable<T> Table => this.Entities;

        protected IDbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                    this.entities = this.context.Set<T>();

                return this.entities;
            }
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);

            this.context.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                this.Entities.Add(entity);

            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.context.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);

            this.context.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                this.Entities.Remove(entity);

            this.context.SaveChanges();
        }
    }
}