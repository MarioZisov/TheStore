namespace TheStore.Site.Base
{
    using TheStore.Core.Domain;

    public interface IEntityModelMap<Entity> where Entity : BaseEntity
    {
        void MapProperties(Entity entity);
    }
}