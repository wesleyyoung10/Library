using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApi.ViewModels
{
    public class ReceiptViewModel
    {
        public string Message { get; set; }
        public DateTime? DuebackDate { get; set; }
    }
}