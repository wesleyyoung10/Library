using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }

    }
}