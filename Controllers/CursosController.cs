using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationExamParcial.Models;

namespace WebApplicationExamParcial.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                return View(contexto.Cursos.ToList());
            }
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                
                var curso = contexto.Cursos.FirstOrDefault(x => x.Id == id);

                if (curso == null)
                {
                    return HttpNotFound(); 
                }

                return View(curso);
            }
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        public ActionResult Create(Cursos curso)
        {
            try
            {
                using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                {
                    
                    contexto.Cursos.Add(curso);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                var curso = contexto.Cursos.Where(x => x.Id == id).FirstOrDefault();

                if (curso == null)
                {
                    return HttpNotFound();  
                }

                return View(curso);
            }
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cursos curso)
        {
            try
            {
                using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                {
                    
                    var cursoExistente = contexto.Cursos.Where(x => x.Id == id).FirstOrDefault();

                    if (cursoExistente != null)
                    {
                        
                        cursoExistente.Nombre_del_curso = curso.Nombre_del_curso;
                        cursoExistente.Nivel = curso.Nivel;
                        cursoExistente.Profesor = curso.Profesor;
                        contexto.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                var curso = contexto.Cursos.Where(x => x.Id == id).FirstOrDefault();

                if (curso == null)
                {
                    return HttpNotFound();  
                }

                return View(curso);
            }
        }

        // POST: Cursos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                {
                    var curso = contexto.Cursos.Where(x => x.Id == id).FirstOrDefault();

                    if (curso != null)
                    {
                        contexto.Cursos.Remove(curso);
                        contexto.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}


