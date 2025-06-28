using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Dtos
{
    public  class GetBookDto
    {
        public Guid BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public bool ISAvailable { get; set; }
    }
}
