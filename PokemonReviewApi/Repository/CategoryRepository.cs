using PokemonReviewApi.Data;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Categories//
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        //Get Category By ID//
        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        //Get Pokemon By Category By Category ID//
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        //Category Exists By ID//
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        //Create Category//
        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        //Update Category//
        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        //Delete Category//
        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        //Save Methode//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}