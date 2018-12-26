namespace TheStore.Site.Data
{
    using System.Data.Entity;
    using TheStore.Site.Domain;

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();
    }
}