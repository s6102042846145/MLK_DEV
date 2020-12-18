using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto.Admin
{
    public class FAQDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img_head { get; set; }
        public string img_tail { get; set; }
        public string detail_hot { get; set; }
        public string detail_tail { get; set; }
        public string detail_hot_mobile { get; set; }
        public string detail_tail_mobile { get; set; }
        public int faq_order { get; set; }
        public int active { get; set; }

    }
}
