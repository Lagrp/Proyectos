using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntitiyResponse<Category>> ListCategories(BaseFilterRequest filters);

        Task<IEnumerable<Category>> ListSelectCategories();

        Task<Category> GetCategoryById(int id);

        Task<bool> RegisterCategory(Category category);

        Task<bool> EditCategory(Category category);

        Task<bool> RemoveCategory(int categoryId);
    }
}