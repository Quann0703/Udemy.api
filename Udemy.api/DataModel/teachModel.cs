using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataModel
{
    public  class teachModel
    {
		public int teachID { get; set; }
		public string Tcname { get; set; }
		public string phonenumber { get; set; }
		public string email { get; set; }
		public string Evaluate { get; set; }
		public string job { get; set; }
		public string? totalCouse { get; set; }
		public string numberstudent { get; set; }
		public string? decribe { get; set; }

    }
}
