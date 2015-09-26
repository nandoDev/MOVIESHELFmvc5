using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MOVIESHELF.Controllers
{
    public class LogOutController : Controller
    {
        //
        // GET: /LogOut/

        public ActionResult Log_Out()
        {
            Session.Abandon();

            //FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
           
        }

        //
        // GET: /LogOut/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /LogOut/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LogOut/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LogOut/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LogOut/Edit/5

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
        // GET: /LogOut/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /LogOut/Delete/5

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
