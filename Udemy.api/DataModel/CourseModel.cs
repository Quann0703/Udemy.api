using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CourseModel
    {

		public int courseID { get; set; }
		public string title { get; set; }
		public string couresImg { get; set; }

		public	string teachID { get; set; }
		public string evaluate { get; set; }
		public int feecoures { get; set; }
		public string? decribe { get; set; }	
		public int topicID { get; set; }
		public string status { get; set; }

		public string Tcname { get; set; }


        public List<LessonModel>? list_json_Lessons { get; set; }
    }
}
