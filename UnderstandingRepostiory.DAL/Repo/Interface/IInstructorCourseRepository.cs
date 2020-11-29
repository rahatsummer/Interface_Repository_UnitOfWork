using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingRepostiory.DAL.Repo.Interface
{
    public interface IInstructorCourseRepository
    {
        tblInstructorCourse GetInstructorCourseById(int? id);

        IEnumerable<tblInstructorCourse> GetAllInstructorCourses();

         int MySave();

         tblInstructorCourse MyAdd(tblInstructorCourse obj);

         tblInstructorCourse MyRemove(tblInstructorCourse obj);
      
    }
}
