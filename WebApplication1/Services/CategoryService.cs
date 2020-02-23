using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CategoryService
    {
        private readonly CRUDContext _context;
        public CategoryService(CRUDContext context)
        {
            _context = context;
        }

        public List<Categories> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public Categories GetCategory(int id)
        {
            var category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            return category;
        }

        public void AddCategory(Categories categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
        }

        public void EditCategory(Categories categories)
        {
            _context.Categories.Update(categories);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var cat = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }
    }
}
