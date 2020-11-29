using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingRepostiory.DAL.Repo.Interface;

namespace UnderstandingRepostiory.DAL.Repo
{
    public class InstructorRepository : IInstructorRepository
    {
        private SchoolDBEntities _db = new SchoolDBEntities();

        public tblInstructor GetInstructorById(int? id)
        {
            return _db.tblInstructors.Find(id);
        }

        public IEnumerable<tblInstructor> GetAllInstructors()
        {
            return _db.tblInstructors.ToList();
        }

        public int MySave()
        {
            return _db.SaveChanges();
        }

        public tblInstructor MyAdd(tblInstructor obj)
        {
            _db.tblInstructors.Add(obj);
            return obj;
        }

        public tblInstructor MyRemove(tblInstructor obj)
        {
            _db.tblInstructors.Remove(obj);
            return obj;
        }
    }
}
