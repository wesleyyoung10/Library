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
    public class AuthorController : ApiController
    {
        [HttpGet]
        [Route("api/authors")]
        public List<AuthorViewModel> GetAuthors()
        {
            var db = new DataContext();

            var authors = db.Authors.ToList();

            var result = new List<AuthorViewModel>();

            foreach (var author in authors)
            {
                result.Add(new AuthorViewModel
                {
                    Id = author.Id,
                    Name = author.Name,
                    Born = author.Born,
                    Died = author.Died
                });
            }

            return result;
        }

        [HttpPut]
        [Route("api/author/add")]
        public AuthorViewModel AddAuthor([System.Web.Http.FromBody]AuthorViewModel author)
        {
            if (author == null)
            {
                return null;
            }

            var db = new DataContext();

            db.Authors.Add(new Author
            {
                Name = author.Name,
                Born = author.Born,
                Died = author.Died,
            });
            db.SaveChanges();

            return author;
        }
    }
}