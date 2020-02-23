using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();

            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult AddSubmit(IFormCollection keyValuePairs)
        {
            var catname = keyValuePairs["categoryname"][0];

            var catdesc = keyValuePairs["categorydesc"][0];

            var categories = new Categories();
            categories.CategoryName = catname;
            categories.Description = catdesc;

            _categoryService.AddCategory(categories);

            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var cat = _categoryService.GetCategory(id);
            return View(cat);
        }

        public IActionResult EditSubmit(IFormCollection keyValuePairs)
        {
            var catname = keyValuePairs["categoryname"][0];

            var catdesc = keyValuePairs["categorydesc"][0];
            var catid = Convert.ToInt32(keyValuePairs["categoryid"][0]);

            var categories = new Categories();
            categories.CategoryName = catname;
            categories.Description = catdesc;
            categories.CategoryId = catid;

            _categoryService.EditCategory(categories);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}