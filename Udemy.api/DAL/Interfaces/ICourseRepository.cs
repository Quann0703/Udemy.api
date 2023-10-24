using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICourseRepository
    {
        List<CourseModel> GetAll();
        CourseModel GetDataById(string courseID);
        bool Create(CourseModel model);
        bool Update(CourseModel model);
        bool Delete(string courseID);

        public List<CourseModel> Search(int page ,int pageSize, out long total,string title);

    }
}
