using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.WebApi.Services;

namespace WebApplication1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices bookservices;
        private readonly CategoryService categoryService;
        public BookController(IBookServices services, CategoryService categoryService)
        {
            this.bookservices = services;
            this.categoryService = categoryService;
        }

       
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            var books = bookservices.GetBook(id);
            return Ok(books);
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = bookservices.GetBooks();
            return Ok(books);
        }


        /// <summary>
        /// This method is to retunr a single for a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category/{categoryid}")]
        public IActionResult GetBookByCategoryId(int categoryid)
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

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetBook(int id)
        //{
        //    var books = bookservices.GetBook(id);
        //    return Ok(books);
        //}




    }
}