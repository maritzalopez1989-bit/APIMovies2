using APIMovies2.DAL.Models;

namespace APIMovies2.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); // Me retorna una lista de categorias
        Task<Category> GetCategoryAsync(int id); // Me retorna una categoria por su Id
        Task<bool> CategoryExistsByIdAsync(int id); // Me dice si una categoria existe por su Id
        Task<bool> CategoryExistsByNameAsync(string name); // Me dice si una categoria existe por su Nombre
        Task<bool> CreateCategoryAsync(Category category); // Crea una nueva categoria
        Task<bool> UpdateCategoryAsync(Category category); // Actualiza una categoria
        Task<bool> DeleteCategoryAsync(int id); // Elimina una categoria
    }
}
