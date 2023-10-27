using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class InvoicesModel
    {

        public int invoicesId { get;set;}
        public int userID { get;set;}
        public int? totalcoins { get;set;}
        public DateTime createDate { get;set;}
        public DateTime? approvaldate { get;set;}
        public string condition { get;set;}

        public List<InvoicesDetailModel>? list_json_InvoicesDetail { get; set; }
    }
}
