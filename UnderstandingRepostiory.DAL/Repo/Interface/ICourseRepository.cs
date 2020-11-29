using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingRepostiory.DAL.Repo.Interface
{
    public interface ICourseRepository
    {
        tblCourse GetCourseById(int? id);


         IEnumerable<tblCourse> GetAllCourses();


        int MySave();


        tblCourse MyAdd(tblCourse obj);


        tblCourse MyRemove(tblCourse obj);
     
    }
}
