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
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: School/Course
        public ActionResult Index()
        {
            List<CourseViewModel> lst = new List<CourseViewModel>();

            var result = _courseRepository.GetAllCourses().ToList();

            foreach (var x in result)
            {
                CourseViewModel courseVM = new CourseViewModel();
                courseVM.Id = x.Id;
                courseVM.CourseName = x.CourseName;
                courseVM.CourseCode = x.CourseCode;
                lst.Add(courseVM);
            }
            return View(lst);
        }

        // GET: School/Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var course = _courseRepository.GetCourseById(id);

            CourseViewModel vm = new CourseViewModel();
            vm.Id = course.Id;
            vm.CourseName = course.CourseName;
            vm.CourseCode = course.CourseCode;

            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: School/Course/Create
        public ActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel();
            return View(courseViewModel);
        }

        // POST: School/Course/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseName,CourseCode")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                tblCourse tc = new tblCourse();

                tc.Id = courseViewModel.Id;
                tc.CourseName = courseViewModel.CourseName;
                tc.CourseCode = courseViewModel.CourseCode;
                _courseRepository.MyAdd(tc);
                _courseRepository.MySave();
                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        // GET: School/Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = _courseRepository.GetCourseById(id);
            CourseViewModel vm = new CourseViewModel();
            vm.Id = course.Id;
            vm.CourseName = course.CourseName;
            vm.CourseCode = course.CourseCode;

            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: School/Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseName,CourseCode")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                tblCourse tc = new tblCourse();
                tc.Id = courseViewModel.Id;
                tc.CourseName = courseViewModel.CourseName;
                tc.CourseCode = courseViewModel.CourseCode;                
                _courseRepository.MySave();
                return RedirectToAction("Index");
            }
            return View(courseViewModel);
        }

        // GET: School/Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = _courseRepository.GetCourseById(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // POST: School/Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCourse tblCourse = _courseRepository.GetCourseById(id);
            _courseRepository.MyRemove(tblCourse);
            _courseRepository.MySave();
            return RedirectToAction("Index");
        }

      
    }
}
