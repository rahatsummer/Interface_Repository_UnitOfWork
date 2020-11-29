using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnderstandingRepostiory.DAL;
using UnderstandingRepostiory.DAL.Repo;
using UnderstandingRepostiory.DAL.Repo.Interface;
using UnderstandRepo.UI.Areas.School.ViewModel;

namespace UnderstandRepo.UI.Areas.School.Controllers
{
    public class InstructorCoursesController : Controller
    {
        private readonly IInstructorCourseRepository _instructorCourseRepository ;
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;

        public InstructorCoursesController(IInstructorRepository instructorRepository, ICourseRepository courseRepository,
                                            IInstructorCourseRepository instructorCourseRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _instructorCourseRepository = instructorCourseRepository;
        }

        // GET: School/InstructorCourses
        public ActionResult Index()
        {
            List<InstructorCourseViewModel> lst = (from ic in _instructorCourseRepository.GetAllInstructorCourses()
                                                   join i in _instructorRepository.GetAllInstructors()
                                                   on ic.InstructorId equals i.Id
                                                   join c in _courseRepository.GetAllCourses()
                                                   on ic.CourseId equals c.Id

                                                   select new InstructorCourseViewModel
                                                   {
                                                       Id = ic.Id,                                                       
                                                       InstructorName = i.InstructorName,
                                                       CourseName = c.CourseName

                                                   }).ToList();
            return View(lst);
            //List<InstructorCourseViewModel> lst = new List<InstructorCourseViewModel>();
            //var result = db.tblInstructorCourses.Include(t => t.tblCourse).Include(t => t.tblInstructor);

            //foreach (var x in result)
            //{
            //    InstructorCourseViewModel icVM = new InstructorCourseViewModel();
            //    icVM.Id = x.Id;
            //    icVM.CourseId = x.Id;
            //    icVM.InstructorId = x.InstructorId;
            //    lst.Add(icVM);

            //}
            
            //return View(lst);
        }

        // GET: School/InstructorCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instructorCourse = _instructorCourseRepository.GetInstructorCourseById(id);
            InstructorCourseViewModel result = (from ic in _instructorCourseRepository.GetAllInstructorCourses()
                                                join c in _courseRepository.GetAllCourses()
                                                on ic.CourseId equals c.Id
                                                join i in _instructorRepository.GetAllInstructors()
                                                on ic.InstructorId equals i.Id
                                                select new InstructorCourseViewModel
                                                {
                                                    Id = ic.Id,
                                                    InstructorName = i.InstructorName,
                                                    CourseName = c.CourseName
                                                }).FirstOrDefault();

            return View(result);
                
               
        }

        // GET: School/InstructorCourses/Create
        public ActionResult Create()
        {
            
            ViewBag.CourseId = new SelectList(_courseRepository.GetAllCourses(), "Id", "CourseName");
            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAllInstructors(), "Id", "InstructorName");
            return View();
        }

        // POST: School/InstructorCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorCourseViewModel instructorCourseViewModel)
        {
            if (ModelState.IsValid)
            {
                tblInstructorCourse tic = new tblInstructorCourse();
                tic.Id = instructorCourseViewModel.Id;
                tic.CourseId = instructorCourseViewModel.CourseId;
                tic.InstructorId = instructorCourseViewModel.InstructorId;
                _instructorCourseRepository.MyAdd(tic);
                _instructorCourseRepository.MySave();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_courseRepository.GetAllCourses(), "Id", "CourseName", instructorCourseViewModel.CourseId);
            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAllInstructors(), "Id", "InstructorName", instructorCourseViewModel.InstructorId);
            return View(instructorCourseViewModel);
        }

        // GET: School/InstructorCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //tblInstructorCourse tblInstructorCourse = db.tblInstructorCourses.Find(id);

            InstructorCourseViewModel result = (from ic in _instructorCourseRepository.GetAllInstructorCourses()
                                                join c in _courseRepository.GetAllCourses()
                                                on ic.CourseId equals c.Id
                                                join i in _instructorRepository.GetAllInstructors()
                                                on ic.InstructorId equals i.Id
                                                where ic.Id == id
                                                select new InstructorCourseViewModel
                                                {
                                                    Id = ic.Id,
                                                    InstructorName = i.InstructorName,
                                                    CourseName = c.CourseName
                                                }).FirstOrDefault();

            ViewBag.CourseId = new SelectList(_courseRepository.GetAllCourses(), "Id", "CourseName", result.CourseId);
            ViewBag.InstructorId = new SelectList(_instructorRepository.GetAllInstructors(), "Id", "InstructorName", result.InstructorId);
            return View(result);
        }

        // POST: School/InstructorCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorCourseViewModel instructorCourseViewModel)
        {
          
                tblInstructorCourse tic = new tblInstructorCourse();
                tic.Id = instructorCourseViewModel.Id;
                tic.CourseId = instructorCourseViewModel.CourseId;
                tic.InstructorId = instructorCourseViewModel.InstructorId;                
                _instructorCourseRepository.MySave();
                return RedirectToAction("Index");
            
            //ViewBag.CourseId = new SelectList(db.tblCourses, "Id", "CourseName", instructorCourseViewModel.CourseId);
            //ViewBag.InstructorId = new SelectList(db.tblInstructors, "Id", "InstructorName", instructorCourseViewModel.InstructorId);
            //return View(instructorCourseViewModel);
        }

        // GET: School/InstructorCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instructorCourse = _instructorCourseRepository.GetInstructorCourseById(id);
            if (instructorCourse == null)
            {
                return HttpNotFound();
            }
            return View(instructorCourse);
        }

        // POST: School/InstructorCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInstructorCourse tblInstructorCourse = _instructorCourseRepository.GetInstructorCourseById(id);           
            _instructorCourseRepository.MySave();
            return RedirectToAction("Index");
        }

       
    }
}
