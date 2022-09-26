using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
