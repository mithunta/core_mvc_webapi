using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.WebApi.Services;

namespace WebApplication1.WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;
        private readonly IBookServices bookservices;
        public CategoryController(CategoryService categoryService, IBookServices services)
        {
            this.categoryService = categoryService;
            bookservices = services;
        }

        [HttpGet]
        [Route("")]
        [Route("getcatories")]
        [Route("getmithuncategories")]
        public IActionResult GetCategories()
        {
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{categoryid}")]
        public IActionResult GetCategory(int categoryid)
        {
            var category = categoryService.GetCategory(categoryid);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(Categories categories)
        {
            categoryService.AddCategory(categories);
            return Ok("Success");
        }

        [HttpPut]
        [Route("{categoryid}")]
        public IActionResult EditCategory(int categoryid, Categories categories)
        {
            categoryService.EditCategory(categoryid, categories);

            return Ok("Success");
        }

        [HttpDelete]
        [Route("{categoryid}")]
        public IActionResult DeleteCategory(int categoryid)
        {
            var result = categoryService.DeleteCategory(categoryid);
            if (result)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid Category Id");
            }
        }


        [HttpGet]
        [Route("{categoryid}/book")]
        public IActionResult GetBooksByCategory(int categoryid)
        {
            var books = bookservices.GetBooksByCategoryId(categoryid);

            if (books.Any())
            {
                return Ok(books);
            }
            else
            {
                return NoContent();
            }
        }
    }
}