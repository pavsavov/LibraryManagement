using LibraryManagement.Data.Models;
using LibraryManagement.Data.Models.Contracts;
using LibraryManagement.Services.BookService.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LibraryManagement.Services.BookService
{
    public class BookService : IService<Book>
    {
        private readonly IMongoCollection<Book> booksCollection;

        public BookService(ILibraryManagementDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.booksCollection = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public async Task<Book> Create(Book entity)
        {
            await this.booksCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result = await this.booksCollection.FindAsync(book => true);
            return await result.ToListAsync();
        }

        public async Task<Book> GetById(string id)
        {
            var books = await this.booksCollection.FindAsync<Book>(unit => unit.Id == id);
            var book = await books.FirstOrDefaultAsync();
            return book;
        }

        public async Task<DeleteResult> RemoveById(string id)
        {
            var result = await booksCollection.DeleteOneAsync<Book>(book => book.Id == id);
            return result;
        }

        public async Task<ReplaceOneResult> Update(string id, Book entity)
        {
            var result = await booksCollection.ReplaceOneAsync<Book>(book => book.Id == id, entity);
            return result;
        }
    }
}
