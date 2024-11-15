using MomProduct.Model;

namespace MomProduct.Service.Interface
{
    public interface IBlogTypeService
    {
        Task<IEnumerable<BlogType>> GetAllAsync();
        Task<BlogType?> GetByIdAsync(int id);
        Task<int> AddAsync(BlogType BlogType);
        Task<int> UpdateAsync(BlogType BlogType);
        Task<int> DeleteAsync(int id);
    }
}
