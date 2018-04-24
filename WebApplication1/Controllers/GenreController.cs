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
    public class GenreController : ApiController
    {
        [HttpGet]
        [Route("api/genres")]
        public List<GenreViewModel> GetGenres()
        {
            var db = new DataContext();

            var genres = db.Genres.ToList();

            var result = new List<GenreViewModel>();

            foreach (var genre in genres)
            {
                result.Add(new GenreViewModel
                {
                    Id = genre.Id,
                    Name = genre.Name,
                });
            }

            return result;
        }

    }
}