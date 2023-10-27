using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class InvoicesDetailModel
    {
        public int invoicesDetailId { get; set; }
        public int invoicesId { get; set; }
        public int courseID { get; set; }
        public int totalCourse { get; set; }
        public DateTime createDatedetail { get; set; }

        public int status { get; set; }

    }
}
