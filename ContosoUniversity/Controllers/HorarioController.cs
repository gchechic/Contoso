using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;
using ContosoUniversity.DAL;

namespace ContosoUniversity.Controllers
{
    public class HorarioController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: /CoureHorario/
        public ActionResult Index()
        {
            return View(db.Horarios.ToList());
        }

        // GET: /CoureHorario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: /CoureHorario/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            return View();
        }

        // POST: /CoureHorario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Horario.ID,Horario.CourseID,Horario.DiaSemana,HDesde,HHasta")] 
        public ActionResult Create(VMHorario vmhorario)
        {
            if (ModelState.IsValid)
            {
                vmhorario.Horario.CourseID = vmhorario.CourseID;
                vmhorario.Horario.DiaSemana  = (int)vmhorario.Dia;
                vmhorario.Horario.HoraDesde = new TimeSpan(vmhorario.HDesde.Horas, vmhorario.HDesde.Minutos, 0);
                vmhorario.Horario.HoraHasta = new TimeSpan(vmhorario.HHasta.Horas, vmhorario.HHasta.Minutos, 0);
                db.Horarios.Add(vmhorario.Horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            return View(vmhorario);
        }

        // GET: /CoureHorario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: /CoureHorario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CourseID,DiaSemana,HoraDesde,HoraHasta")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // GET: /CoureHorario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: /CoureHorario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horarios.Find(id);
            db.Horarios.Remove(horario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
