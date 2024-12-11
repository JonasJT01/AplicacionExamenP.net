using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationExamParcial.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using WebApplicationExamParcial.Models;  

    public class EstudiantesController : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                
                var estudiantes = contexto.Estudiantes.ToList();
                return View(estudiantes); 
            }
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                
                var estudiante = contexto.Estudiantes.FirstOrDefault(x => x.Id == id);

                if (estudiante == null)
                {
                    return HttpNotFound();  
                }

                return View(estudiante);  
            }
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();  
        }

        // POST: Estudiantes/Create
        [HttpPost]
        public ActionResult Create(Estudiantes estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                    {
                       
                        contexto.Estudiantes.Add(estudiante);
                        contexto.SaveChanges();  
                    }

                    return RedirectToAction("Index");  
                }

                return View(estudiante);  
            }
            catch
            {
                return View();  
            }
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                
                var estudiante = contexto.Estudiantes.FirstOrDefault(x => x.Id == id);

                if (estudiante == null)
                {
                    return HttpNotFound();  
                }

                return View(estudiante);  
            }
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Estudiantes estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                    {
                        
                        var estudianteExistente = contexto.Estudiantes.FirstOrDefault(x => x.Id == id);

                        if (estudianteExistente != null)
                        {
                           
                            estudianteExistente.Nombre = estudiante.Nombre;
                            estudianteExistente.Carrera = estudiante.Carrera;
                            estudianteExistente.CorreoElectronico = estudiante.CorreoElectronico;

                            
                            contexto.SaveChanges();
                        }
                    }

                    return RedirectToAction("Index");  
                }

                return View(estudiante);  
            }
            catch
            {
                return View();  
            }
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            using (BD_ColegioEntities contexto = new BD_ColegioEntities())
            {
                
                var estudiante = contexto.Estudiantes.FirstOrDefault(x => x.Id == id);

                if (estudiante == null)
                {
                    return HttpNotFound();  
                }

                return View(estudiante);  
            }
        }

        // POST: Estudiantes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BD_ColegioEntities contexto = new BD_ColegioEntities())
                {
                   
                    var estudiante = contexto.Estudiantes.FirstOrDefault(x => x.Id == id);

                    if (estudiante != null)
                    {
                        
                        contexto.Estudiantes.Remove(estudiante);
                        contexto.SaveChanges();  
                    }
                }

                return RedirectToAction("Index");  
            }
            catch
            {
                return View();  
            }
        }
    }
}

