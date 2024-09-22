using API_Bibliotek.Models;
using API_Bibliotek.Models.DTOs;
using Bibliotek_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace Bibliotek_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book/Index
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        // GET: Book/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDTO bookDto)
        {
            if (ModelState.IsValid)
            {
                var success = await _bookService.CreateBookAsync(bookDto);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bookDto);
        }

        // GET: Book/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Konvertera BookDTO till UpdateBookDTO
            var updateBookDto = new UpdateBookDTO
            {
                id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Genre = book.Genre,
                Description = book.Description,
                IsAvailable = book.IsAvailable
            };

            return View(updateBookDto);  // Skicka rätt typ (UpdateBookDTO) till vyn
        }

        // POST: Book/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookDTO bookDto)
        {
            if (ModelState.IsValid)
            {
                var success = await _bookService.UpdateBookAsync(bookDto);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bookDto);
        }

        // POST: Book/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}