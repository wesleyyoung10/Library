using LibraryApi.Data;
using System.Data.Entity;
using LibraryApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryApi.Controllers
{
    public class CheckingOutController : ApiController
    {
        [HttpPut]
        [Route("api/book/{bookId}/checkin")]
        public ReceiptViewModel Checkin([FromUri]int bookId)
        {
            var db = new DataContext();

            var book = db.Books.Single(s => s.Id == bookId);

            if (!book.IsCheckedOut)
            {
                return new ReceiptViewModel
                {
                    Message = "Book not checked out"
                };
            }
            else
            {
                book.IsCheckedOut = false;
                book.DueBackDate = null;

                db.SaveChanges();

                return new ReceiptViewModel
                {
                    Message = "Thanks for not sucking"
                };
            }
        }
        [HttpPut]
        [Route("api/book/{bookId}/checkout")]
        public ReceiptViewModel Checkout([FromUri]int bookId)
        {
            var db = new DataContext();

            var book = db.Books.Single(s => s.Id == bookId);

            if (!book.IsCheckedOut)
            {
                book.IsCheckedOut = true;

                book.DueBackDate = DateTime.Now.AddDays(10);

                db.SaveChanges();

                return new ReceiptViewModel
                {
                    Message = "Book checked out",

                    DuebackDate = book.DueBackDate
                };
            }
            else
            {
                return new ReceiptViewModel
                {
                    Message = "Book checked out",

                    DuebackDate = book.DueBackDate
                };
            }
        }
    }
}