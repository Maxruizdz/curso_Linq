using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_linq
{
    internal class Book

    {
        public string Title { get; set; }
        public int PageCount { get; set; }
         public string status { get; set; }
        public DateTime PublishedDate { get; set; }
        public string[] Autors { get; set; }

        public string[] Categories { get; set; }
        
    }
}
