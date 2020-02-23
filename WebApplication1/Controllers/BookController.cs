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
    public class BookController : Controller
    {
        private readonly IBookServices bookservices;
        private readonly CategoryService categoryService;
        public BookController(IBookServices services, CategoryService categoryService)
        {
            this.bookservices = services;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var books = bookservices.GetBooks();
            return View(books);
        }
        public IActionResult AddBook()
        {
            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult AddSubmit(IFormCollection keyValuePairs)
        {
            var bookname = keyValuePairs["bookname"][0];
            var bookprice = keyValuePairs["bookprice"][0];
            var bookinstock = keyValuePairs["bookinstock"][0];
            var categoryid = keyValuePairs["category"][0];

            Books books = new Books();
            books.BookName = bookname;
            books.BookPrice = Convert.ToDecimal(bookprice);
            if(bookinstock == "on")
            {
                books.BookInStock = true;
            }
            else
            {
                books.BookInStock = false;
            }
            books.CategoryId = Convert.ToInt32(categoryid);

            bookservices.AddBook(books);

            return RedirectToAction("Index");
        }
        public IActionResult EditBook(int id)
        {
            var categories = categoryService.GetCategories();
            var book = bookservices.GetBook(id);

            // Composite Class - View Model
            EditBookViewModel vm = new EditBookViewModel();
            vm.Books = book;
            vm.Categories = categories;

            return View(vm);
        }

        public IActionResult EditSubmit(IFormCollection keyValuePairs)
        {
            var bookname = keyValuePairs["bookname"][0];
            var bookprice = keyValuePairs["bookprice"][0];
            var bookinstock = "off";
            if (keyValuePairs.ContainsKey("bookinstock"))
            {
                bookinstock = keyValuePairs["bookinstock"][0];
            }
            var categoryid = keyValuePairs["category"][0];
            var bookid = keyValuePairs["bookid"][0];

            Books books = new Books();
            books.BookName = bookname;
            books.BookId = Convert.ToInt32(bookid);
            books.BookPrice = Convert.ToDecimal(bookprice);
            if (bookinstock == "on")
            {
                books.BookInStock = true;
            }
            else
            {
                books.BookInStock = false;
            }
            books.CategoryId = Convert.ToInt32(categoryid);

            bookservices.EditBook(books);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(int id)
        {
            bookservices.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}