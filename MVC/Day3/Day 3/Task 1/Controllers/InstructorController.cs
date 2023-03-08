using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class InstructorController : Controller
    {
        ITIEntities context =  new ITIEntities();
        // GET: Instructor
        public ActionResult Index()
        {
            return View(context.Instructors.ToList());
        }

        [HttpPost]
        public ActionResult Index(int Dept_Id)
        {
            var Insts = context.Instructors.Where(I => I.Dept_Id == Dept_Id);
            return View(Insts);
        }
        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            var inst = context.Instructors.FirstOrDefault(i => i.Ins_Id == id);
            return View(inst);
        } 

        // GET: Instructor/Create
        public ActionResult Create()
        {
            ViewBag.Insts = context.Departments.ToList();
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var selectedInst = new Instructor();
                selectedInst.Ins_Id = int.Parse(collection["Ins_Id"]);
                selectedInst.Ins_Name = collection["Ins_Name"];
                selectedInst.Ins_Degree = collection["Ins_Degree"];
                selectedInst.Salary = decimal.Parse(collection["Salary"]);
                selectedInst.Dept_Id = int.Parse(collection["Dept_Id"]);

                context.Instructors.Add(selectedInst);
                context.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Depts = context.Departments.ToList();
            var selectedInst = context.Instructors.FirstOrDefault(inst => inst.Ins_Id == id);
            return View(selectedInst);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Instructor selectedInst = context.Instructors.FirstOrDefault(inst => inst.Ins_Id == id);
                selectedInst.Ins_Name = collection["Ins_Name"];
                selectedInst.Ins_Degree= collection["Ins_Degree"];
                selectedInst.Salary = decimal.Parse(collection["Salary"]);
                selectedInst.Dept_Id = int.Parse(collection["Dept_Id"]);

                context.SaveChanges();

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Instructor selectedInst = context.Instructors.Find(id);
                context.Instructors.Remove(selectedInst);

                context.SaveChanges();
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
