using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthCareCrud.Models;
using HealthCareCrud.Data;

namespace HealthCareCrud.Controllers
{
    public class PatientController : Controller
    {
      readonly  PatientDbContext _patientDbContext =new PatientDbContext();

        // GET: Patient
        public ActionResult GetAllPatient()
        {
            var ListOfPatient = _patientDbContext.Patients.ToList();
            return View(ListOfPatient);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient p)
        {
            if (p == null)
            {
                ViewBag.Message = "Please enter valid data";
            }

            _patientDbContext.Patients.Add(p);  
            _patientDbContext.SaveChanges();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var editrow = _patientDbContext.Patients.Where(m=>m.ID == id).FirstOrDefault();  
        return View(editrow);
        }

        [HttpPost]
      public ActionResult Edit(Patient p)
        {
            _patientDbContext.Entry(p).State=System.Data.Entity.EntityState.Modified;
            int a = _patientDbContext.SaveChanges();
            if(a>0)
            {
                //only in same action method
                ViewBag.Editmessage = "<script>alert(updated)</script>";
                TempData["Editmessage"] = "<script>alert(updated)</script>";
            }
            return RedirectToAction("GetAllPatient");
        }
        public ActionResult Delete(int id)

        {
            var deleterow = _patientDbContext.Patients.Where(m => m.ID == id).FirstOrDefault();
            return View(deleterow);
        }

        [HttpPost]
        public ActionResult Delete(Patient p)
        {
            // _patientDbContext.Entry(p).State=System.Data.Entity.EntityState.Deleted;
            // int a=   _patientDbContext.SaveChanges();
            var history = _patientDbContext.PatientHistory.Where(x=>x.Patient.ID==p.ID).ToList();
            if (history.Any())
            {
                _patientDbContext.PatientHistory.RemoveRange(history);
            }
            _patientDbContext.Patients.Attach(p);

            _patientDbContext.Patients.Remove(p);
            _patientDbContext.SaveChanges();

        
            return RedirectToAction("GetAllPatient");
        }




    }
}