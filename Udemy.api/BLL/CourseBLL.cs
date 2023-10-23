using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseBLL : ICourseBLL
    {
        private ICourseRepository _res;
        public CourseBLL(ICourseRepository res)
        {
            _res = res;
        }

        public List<CourseModel> GetAll()
        {
            return _res.GetAll();
        }
        public CourseModel GetDataById(string CourseId)
        {
            return _res.GetDataById(CourseId);
        }

        public bool Create(CourseModel model)
        {
            return _res.Create(model);
        }

        public bool Update(CourseModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string CourseId)
        {
            return _res.Delete(CourseId);
        }
    }
}
