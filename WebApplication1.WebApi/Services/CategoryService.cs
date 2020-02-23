using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.WebApi.Services
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

        public void EditCategory(int categoryid, Categories categories)
        {
            categories.CategoryId = categoryid;
            _context.Categories.Update(categories);
            _context.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            var cat = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
