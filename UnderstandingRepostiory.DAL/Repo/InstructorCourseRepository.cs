using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingRepostiory.DAL.Repo.Interface;

namespace UnderstandingRepostiory.DAL.Repo
{
    public class InstructorCourseRepository : IInstructorCourseRepository
    {
        private SchoolDBEntities _db = new SchoolDBEntities();

        public tblInstructorCourse GetInstructorCourseById(int? id)
        {
            return _db.tblInstructorCourses.Find(id);
        }

        

        public IEnumerable<tblInstructorCourse> GetAllInstructorCourses()
        {
            return _db.tblInstructorCourses.ToList();
        }

        public int MySave()
        {
            return _db.SaveChanges();
        }

        public tblInstructorCourse MyAdd(tblInstructorCourse obj)
        {
            _db.tblInstructorCourses.Add(obj);
            return obj;
        }

        public tblInstructorCourse MyRemove(tblInstructorCourse obj)
        {
            _db.tblInstructorCourses.Remove(obj);
            return obj;
        }


    }
}
