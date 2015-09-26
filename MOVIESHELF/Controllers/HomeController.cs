using MOVIESHELF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MOVIESHELF.Controllers
{
    public class HomeController : Controller
    {
        
        //
        // GET: /InicioLogin/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login (User u)
        {
            //This action is for handle Post (login)
            if (ModelState.IsValid)
            {
              using (DATABASE_MOVIESHELFEntities1 store_Db = new DATABASE_MOVIESHELFEntities1())
              { 
                var v= store_Db.Users.Where(a=>a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                  if (v!=null)
                  {
                      Session["LogedUserId"] = v.IdUsers.ToString();
                      Session["LogedUsername"] = v.Username.ToString();
                      return RedirectToAction("Index", "Store");

                  }
                  else
                  { ModelState.AddModelError("", "Invalid username or password");
                  return RedirectToAction("Login", "Home");
                  }
              }

            }
            return RedirectToAction("Login", "Home");
        }

        //
        // GET: /InicioLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /InicioLogin/Create
        [ChildActionOnly]
        public ActionResult register()
        {
            return PartialView();
        }

        //
        // POST: /InicioLogin/Create

        [HttpPost]
        public ActionResult register(User u)
        {
            if (ModelState.IsValid)
            {
                using (DATABASE_MOVIESHELFEntities1 store_Db = new DATABASE_MOVIESHELFEntities1())
                {
                    store_Db.Users.Add(u);
                    store_Db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "You have been succesfully registered";
                }

            } 
            return View(u);
        }

        //
        // GET: /InicioLogin/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /InicioLogin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /InicioLogin/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /InicioLogin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
