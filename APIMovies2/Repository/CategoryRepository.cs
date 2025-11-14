using APIMovies2.DAL;
using APIMovies2.DAL.Models;
using APIMovies2.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIMovies2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);

        }


        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
                 .AsNoTracking()
                 .AnyAsync(c => c.Name == name);

        }
        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            var addedCategory = await _context.Categories.AddAsync(category);

            return await _context.SaveChangesAsync() >= 0 ? true : false;


        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);// primero consulta que exista la categoria
            if (category == null)
            {
                return false; // la categoria no existe
            }
            _context.Categories.Remove(category); // si existe la elimina
            return await _context.SaveChangesAsync() >= 0 ? true : false; // guarda los cambios y retorna true si se guardo correctamente
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                 .AsNoTracking()
                 .OrderBy(c => c.Name)
                 .ToListAsync();


        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);


        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
            _context.Categories.Update(category);

            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
        
        private async Task<bool> SaveAsync()    
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}