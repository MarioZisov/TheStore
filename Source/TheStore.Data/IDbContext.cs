namespace TheStore.Data
{
    using System.Data.Entity;
    using TheStore.Core.Domain;

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();
    }
}