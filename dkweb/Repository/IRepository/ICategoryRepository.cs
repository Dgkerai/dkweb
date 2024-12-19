using dkweb.Data;

namespace dkweb.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category obj);
        public Task<Category> UpdateAsync(Category obj);
        public Task<bool> DeleteAsync(int Id);
        public Task<Category> GetAsync(int Id);
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
