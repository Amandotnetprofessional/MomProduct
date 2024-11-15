using MomProduct.Model;

namespace MomProduct.Service
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<int> AddAsync(Blog Blog);
        Task<int> UpdateAsync(Blog Blog);
        Task<int> DeleteAsync(int id);
    }
}
