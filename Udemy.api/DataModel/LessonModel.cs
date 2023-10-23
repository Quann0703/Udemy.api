using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LessonModel
    {
		public int lessonID { get; set; }
		public	string lessonName { get; set; }
		public string videoID { get; set; }
		public int courseID { get; set; }

		public int status { get; set; }

        public string? decribe { get; set; }
        public string? img { get; set; }
		public string? time { get; set; }
		public string? content { get; set; }
		
    }
}
