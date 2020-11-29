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
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instuctorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instuctorRepository = instructorRepository;
        }

        // GET: School/Instructor
        public ActionResult Index()
        {
            List<InstructorViewModel> listInstructor = new List<InstructorViewModel>();
            var result = _instuctorRepository.GetAllInstructors();
            foreach(var x in result)
            {
                InstructorViewModel instructorVM = new InstructorViewModel();
                instructorVM.Id = x.Id;
                instructorVM.InstructorName = x.InstructorName;
                instructorVM.InstructorContact = x.InstructorContact;
                listInstructor.Add(instructorVM);
            }
            return View(listInstructor);
        }

        // GET: School/Instructor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var instructor = _instuctorRepository.GetInstructorById(id);

            InstructorViewModel vm = new InstructorViewModel();
            vm.Id = instructor.Id;
            vm.InstructorName = instructor.InstructorName;
            vm.InstructorContact = instructor.InstructorContact;

            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: School/Instructor/Create
        public ActionResult Create()
        {
            InstructorViewModel instructorVM = new InstructorViewModel();
            return View(instructorVM);
        }

        // POST: School/Instructor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstructorName,InstructorContact")] InstructorViewModel InstructorVM)
        {
            if (ModelState.IsValid)
            {
                tblInstructor it = new tblInstructor();
                it.Id = InstructorVM.Id;
                it.InstructorName = InstructorVM.InstructorName;
                it.InstructorContact = InstructorVM.InstructorContact;
                _instuctorRepository.MyAdd(it);
                _instuctorRepository.MySave();
                return RedirectToAction("Index");
            }

            return View(InstructorVM);
        }

        // GET: School/Instructor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instructor = _instuctorRepository.GetInstructorById(id);
            InstructorViewModel vm = new InstructorViewModel();
            vm.Id = instructor.Id;
            vm.InstructorName = instructor.InstructorName;
            vm.InstructorContact = instructor.InstructorContact;
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: School/Instructor/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstructorName,InstructorContact")] InstructorViewModel instructorVM)
        {
            if (ModelState.IsValid)
            {
                tblInstructor it = new tblInstructor();
                it.Id = instructorVM.Id;
                it.InstructorName = instructorVM.InstructorName;
                it.InstructorContact = instructorVM.InstructorContact;
                //db.Entry(it).State = EntityState.Modified;
                _instuctorRepository.MySave();
                return RedirectToAction("Index");
            }
            return View(instructorVM);
        }

        // GET: School/Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var instructor = _instuctorRepository.GetInstructorById(id);

            //tblInstructor tblInstructor = db.tblInstructors.Find(id);
            
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: School/Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInstructor it = _instuctorRepository.GetInstructorById(id);
            _instuctorRepository.MyRemove(it);
            _instuctorRepository.MySave();
            return RedirectToAction("Index");
        }

    
    }
}
