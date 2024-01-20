namespace Sgcm.Dominio.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> GeatAll();

        IEnumerable<Entity> GetByFieldValue(string field, string value);

        Entity GetById(string entityId);

        int Save(string entityId);

        int Delete(string entityId);

        int Clear();
    }

    public interface IBaseRepositoryAsync<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GeatAllAsync();

        Task<IEnumerable<Entity>> GetByFieldValueAsync(string value, string field="");

        Task<Entity> GetByIdAsync(string entityId);

        Task<int> SaveAsync(Entity entity);

        Task<int> DeleteAsync(string entityId);

        Task<int> ClearAsync();
    }
}