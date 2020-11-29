using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingRepostiory.DAL.Repo.Interface
{
    public interface IInstructorRepository
    {
        tblInstructor GetInstructorById(int? id);


        IEnumerable<tblInstructor> GetAllInstructors();


        int MySave();


        tblInstructor MyAdd(tblInstructor obj);


        tblInstructor MyRemove(tblInstructor obj);
       
    }
}
