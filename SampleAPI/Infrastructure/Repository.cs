using SampleAPI.Models;
using System.Linq;
namespace SampleAPI.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IList<Entity> _entities = new List<Entity>();
        public Entity Get(String id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }
        public List<Entity> GetAll()
        {
            return _entities.ToList();
        }
        public Boolean Insert(Entity entity)
        {
            _entities.Add(entity);
            return true;
        }
        public Boolean Update(Entity entity)
        {
            Delete(entity);
            Insert(entity);
            return true;
        }
        public Boolean Delete(Entity entity)
        {
            var value = Get(entity.Id);
            if (value != null)
            {
                _entities.Remove(value);
            }
            return true;
        }

        public IQueryable<Entity> Query()
        {
            return _entities.AsQueryable();
        }

    }
}
