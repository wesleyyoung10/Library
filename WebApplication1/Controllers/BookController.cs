using LibraryApi.Data;
using LibraryApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("api/books/findnotcheckedout")]
        public List<BookViewModel> FindBooksNotCheckedOut()
        {
            var db = new DataContext();

            var book = db.Books.Where(b => b.IsCheckedOut == false).Select(b => new BookViewModel
            {
                Id = b.Id,
                BookName = b.Title,
                YearPublished = b.YearPublished,
                AuthorName = b.Author.Name,
                GenreName = b.Genre.Name,
                IsCheckedOut = b.IsCheckedOut
            }).ToList();

            return book;
        }

        [HttpGet]
        [Route("api/books/findcheckedout")]
        public List<BookViewModel> FindBooksCheckedOut()
        {
            var db = new DataContext();

            var book = db.Books.Where(b => b.IsCheckedOut).Select(b => new BookViewModel
            {
                Id = b.Id,
                BookName = b.Title,
                YearPublished = b.YearPublished,
                AuthorName = b.Author.Name,
                GenreName = b.Genre.Name,
                IsCheckedOut = b.IsCheckedOut
            }).ToList();

            return book;
        }

        [HttpGet]
        [Route("api/books/findbyname/{name}")]
        public BookViewModel FindBookByName(string name)
        {
            var db = new DataContext();

            var book = db.Books.Where(b => b.Title == name).Select(b => new BookViewModel
            {
                Id = b.Id,
                BookName = b.Title,
                YearPublished = b.YearPublished,
                AuthorName = b.Author.Name,
                GenreName = b.Genre.Name,
                IsCheckedOut = b.IsCheckedOut
            }).FirstOrDefault();

            return book;
        }

        [HttpGet]
        [Route("api/books/findbygenre/{genreId}")]
        public List<BookViewModel> FindBooksByGenreId(int genreId)
        {
            var db = new DataContext();

            var books = db.Books.Where(b => b.GenreId == genreId).Select(b => new BookViewModel
            {
                Id = b.Id,
                BookName = b.Title,
                YearPublished = b.YearPublished,
                AuthorName = b.Author.Name,
                GenreName = b.Genre.Name,
                IsCheckedOut = b.IsCheckedOut
            }).ToList();

            return books;
        }

        [HttpGet]
        [Route("api/books/findbyauthor/{authorId}")]
        public List<BookViewModel> FindBooksByAuthorId(int authorId)
        {
            var db = new DataContext();

            var books = db.Books.Where(b => b.AuthorId == authorId).Select(b => new BookViewModel
            {
                Id = b.Id,
                BookName = b.Title,
                YearPublished = b.YearPublished,
                AuthorName = b.Author.Name,
                GenreName = b.Genre.Name,
                IsCheckedOut = b.IsCheckedOut
            }).ToList();

            return books;
        }

        [HttpPut]
        [Route("api/book/add")]
        public BookViewModel AddBook([FromBody]BookViewModel book)
        {
            if (book == null)
            {
                return null;
            }

            var db = new DataContext();

            var bookEntity = new Book
            {
                Title = book.BookName,
                YearPublished = book.YearPublished,
                Condition = book.Condition,
                ISBN = book.ISBN,
                IsCheckedOut = false,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId

            };

            db.Books.Add(bookEntity);

            db.SaveChanges();

            book.Id = bookEntity.Id;

            return book;
        }

        [HttpGet]
        [Route("api/books")]
        public List<BookViewModel> Get()
        {
            var db = new DataContext();

            var data = db.Books
               
                .Include(i => i.Author)
                
                .Include(i => i.Genre)
               
                .ToList();

            var rv = data.Select(book => new BookViewModel
            {
                Id = book.Id,

                BookName = book.Title,

                AuthorName = book.Author.Name,

                GenreName = book.Genre.Name,

                YearPublished = book.YearPublished,

                IsCheckedOut = book.IsCheckedOut
            }).ToList();

            return rv;
        }

    }
}