using dkweb.Data;
using dkweb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace dkweb.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Categories.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int Id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objfromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objfromDb != null)
            {
                objfromDb.Name = obj.Name;
                _db.Categories.Update(objfromDb);
                await _db.SaveChangesAsync();
                return objfromDb;
            }
            return obj;
        }
    }
}
