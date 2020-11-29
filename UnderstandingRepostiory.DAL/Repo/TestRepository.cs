using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingRepostiory.DAL.Repo.Interface;

namespace UnderstandingRepostiory.DAL.Repo
{
    class TestRepository : ICourseRepository
    {
        public IEnumerable<tblCourse> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public tblCourse GetCourseById(int? id)
        {
            throw new NotImplementedException();
        }

        public tblCourse MyAdd(tblCourse obj)
        {
            throw new NotImplementedException();
        }

        public tblCourse MyRemove(tblCourse obj)
        {
            throw new NotImplementedException();
        }

        public int MySave()
        {
            throw new NotImplementedException();
        }
    }
}
