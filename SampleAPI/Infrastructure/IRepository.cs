using SampleAPI.Models;

namespace SampleAPI.Infrastructure
{
    public interface IRepository
    {
        bool Delete(Entity entity);
        Entity Get(string id);
        List<Entity> GetAll();
        bool Insert(Entity entity);
        bool Update(Entity entity);
        IQueryable<Entity> Query();
    }
}