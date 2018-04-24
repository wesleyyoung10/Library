using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApi.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int YearPublished { get; set; }
        public string Condition { get; set; }
        public int ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}