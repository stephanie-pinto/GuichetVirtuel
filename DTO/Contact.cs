using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contact
    {
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Objet { get; set; }
        public int Message { get; set; }
    }
}
