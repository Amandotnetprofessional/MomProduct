using MomProduct.Model;

namespace MomProduct.Service.Interface
{
    public interface IBlogTemplateService
    {
        Task<IEnumerable<BlogTemplate>> GetAllAsync();
        Task<BlogTemplate?> GetByIdAsync(int id);
        Task<int> AddAsync(BlogTemplate blogTemplate);
        Task<int> UpdateAsync(BlogTemplate blogTemplate);
        Task<int> DeleteAsync(int id);
    }
}
