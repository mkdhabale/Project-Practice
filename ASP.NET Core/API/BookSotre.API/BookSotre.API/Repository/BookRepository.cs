using AutoMapper;
using BookSotre.API.Data;
using BookSotre.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSotre.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // This is an manual conversion, recommented is automapper which is useful for large number properties
            /*var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title= x.Title,
                Description = x.Description
            }).ToListAsync();
            return records;*/

            //using automapper
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }


        public async Task<BookModel> GetAllBooksByIdAsync(int bookId)
        {
            //FindAsync will work only with primary key
            /* var records = await _context.Books.FindAsync(bookId).Select(x => new BookModel()
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description
             });*/

            //find by where condtion for all other condition
            //without automaper
            /*var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description
             }).FirstOrDefaultAsync();
             return records;*/

            //using automapper
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }


        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }


        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //hitting db 2 times for upadte which is not recommended
            /*var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;
                await _context.SaveChangesAsync();
            }   */


            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
