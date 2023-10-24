using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public  interface ICourseBLL
    {
        List<CourseModel> GetAll();
        CourseModel GetDataById(string courseID);
        bool Create(CourseModel model);
        bool Update(CourseModel model);
        bool Delete(string courseID);
        public List<CourseModel> Search(int page, int pageSize, out long total, string title);
    }
}
