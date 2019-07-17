using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject.ViewModels
{
    class BookInput
    {
        public BookInput()
        {

        }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Translator { get; set; }
        public string Publisher { get; set; }
        public int PublishedDate { get; set; }
        public string Circulation { get; set; }
        public double Price { get; set; }
		public string ISBN { get; set; }

	}
}
