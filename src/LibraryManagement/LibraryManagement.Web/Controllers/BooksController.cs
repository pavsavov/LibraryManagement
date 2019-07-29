using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.Models;
using LibraryManagement.Services.BookService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksControler : ControllerBase
    {
        private readonly IService<Book> bookServices;
        public BooksControler(IService<Book> bookServices)
        {
            this.bookServices = bookServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await this.bookServices.GetAll();

            if (books == null)
            {
                return NotFound();
            }

            return this.Ok(books);
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid id!");
            }

            var book = await this.bookServices.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return this.Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (book == null)
            {
                return NoContent();
            }
            var createBook = await this.bookServices.Create(book);

            if (createBook == null)
            {
                return this.Ok(createBook);
            }

            return this.CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book bookIn)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid id!");
            }

            var bookUnit = this.bookServices.GetById(id);

            if (bookUnit == null)
            {
                return this.NotFound();
            }

            var result = await this.bookServices.Update(id, bookIn);

            if (!result.IsAcknowledged)
            {
                return this.Content("Update process failed!");
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid id");
            }

            var deleteResult = await this.bookServices.RemoveById(id);

            if (!deleteResult.IsAcknowledged)
            {
                return this.Content("Delete process failed!");
            }

            return Ok();
        }
    }
}
