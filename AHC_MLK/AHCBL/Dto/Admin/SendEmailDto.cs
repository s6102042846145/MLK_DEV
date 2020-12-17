using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto.Admin
{
    public class SendEmailDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string active { get; set; }
    }
}
