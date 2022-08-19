using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumirAPI
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? Pages { get; set; }
        public int? Year { get; set; }
    }
}
