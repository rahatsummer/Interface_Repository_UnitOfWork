using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingRepostiory.DAL.Repo.Interface;

namespace UnderstandingRepostiory.DAL.Repo
{
    public class CourseRepository : ICourseRepository
    {
        private SchoolDBEntities _db = new SchoolDBEntities();

        public tblCourse GetCourseById(int? id)
        {
            return _db.tblCourses.Find(id);
        }

        public IEnumerable<tblCourse> GetAllCourses()
        {
            return _db.tblCourses.ToList();
        }

        public int MySave()
        {
            return _db.SaveChanges();
        }

        public tblCourse MyAdd(tblCourse obj)
        {
            _db.tblCourses.Add(obj);
            return obj;
        }

        public tblCourse MyRemove(tblCourse obj)
        {
            _db.tblCourses.Remove(obj);
            return obj;
        }
    }
}
