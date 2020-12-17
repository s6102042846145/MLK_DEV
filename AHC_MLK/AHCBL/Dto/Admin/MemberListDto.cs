using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AHCBL.Dto.Admin
{
    public class MemberListDto
    {
        [Display(Name = "id")]
        public int id { get; set; }
        [Required(ErrorMessage = "xxx.")]
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string nickname { get; set; }
        public int level { get; set; }
        public int point { get; set; }
        public string email { get; set; }
        public string homepage { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string certify_case { get; set; }
        public string certify { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string icon { get; set; }
        public string img { get; set; }
        public string mailling { get; set; }
        public string sms { get; set; }
        public string open { get; set; }
        public string signature { get; set; }
        public string profile { get; set; }
        public string memo { get; set; }
        public string adviser { get; set; }
        public string leave_date { get; set; }
        public string intercept_date { get; set; }
        public string txt1 { get; set; }
        public string txt2 { get; set; }
        public string txt3 { get; set; }
        public string txt4 { get; set; }
        public string txt5 { get; set; }
        public string txt6 { get; set; }
        public string txt7 { get; set; }
        public string txt8 { get; set; }
        public string txt9 { get; set; }
        public string txt10 { get; set; }
        public string active { get; set; }
        public string status { get; set; }
    }
}

