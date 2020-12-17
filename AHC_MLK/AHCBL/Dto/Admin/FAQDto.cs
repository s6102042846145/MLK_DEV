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
        public string img_t { get; set; }
        public string img_b { get; set; }
        public string detail_hot { get; set; }
        public string detail_buttom { get; set; }
        public string detail_hot_mobile { get; set; }
        public string detail_buttom_mobile { get; set; }
        public string faq_order { get; set; }
        public string status { get; set; }

    }
}
