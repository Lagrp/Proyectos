using Sgcm.Dominio.Entidades;

namespace Sgcm.Dominio.Interfaces
{
    public interface IUserRepository : IBaseRepositoryAsync<User>
    {
        Task<User> GetValidUser(string user, string password);
    }
}