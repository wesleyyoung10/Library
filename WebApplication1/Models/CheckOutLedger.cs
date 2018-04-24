using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class CheckOutLedger
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
