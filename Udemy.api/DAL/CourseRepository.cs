using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class CourseRepository:ICourseRepository
    {
        private IDatabaseHelper _db;
        public CourseRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public List<CourseModel> GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery("sp_course_GetAll");
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return data.ConvertTo<CourseModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CourseModel GetDataById(string CourseId)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_get_course_by_id",
                    "@CourseId",
                    CourseId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<CourseModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(CourseModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
                "sp_course_create",
                "@couresImg", model.couresImg,
                "@title", model.title,
                "@teachID", model.teachID,
                "@evaluate", model.evaluate,
                "@decribe", model.decribe,
                "@feecoures", model.feecoures,
                "@topicID",model.topicID,
                "@list_json_lessons", model.list_json_Lessons != null ? MessageConvert.SerializeObject(model.list_json_Lessons) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(CourseModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_course_update",

                "@courseID", model.courseID,
                "@couresImg", model.couresImg,
                "@title", model.title,
                "@teachID", model.teachID,
                "@evaluate", model.evaluate,
                "@decribe", model.decribe,
                "@feecoures", model.feecoures,
                "@topicID", model.topicID,
                "@status",model.status,
                "@list_json_lessons", model.list_json_Lessons != null ? MessageConvert.SerializeObject(model.list_json_Lessons) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string courseID)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_course_delete",
                "@CourseId", courseID);
                ;
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseModel> Search(int page, int pageSize, out long total, string title)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_course_search",
                    "@page_index", page,
                    "@page_size", pageSize,
                    "@name", title
                    );
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                    return dt.ConvertTo<CourseModel>().ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
