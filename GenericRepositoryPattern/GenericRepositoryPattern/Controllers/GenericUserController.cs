using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestProject.Controllers
{
    public class GenericUserController : Controller
    {
        private IGenericRepository<User> repository = null;

        //public User2Controller()
        //{
        //    this.repository = new GenericRepository<User2>();
        //}
        public GenericUserController(IGenericRepository<User> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "GenericUser");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            User model = repository.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "GenericUser");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DetailsEmployee(int id)
        {
            User model = repository.GetById(id);
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            //var user = repository.GetById(id);
            repository.Delete(id);
            repository.Save();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public ActionResult DeleteEmployee(int id)
        //{
        //    repository.Delete(id);
        //    repository.Save();
        //    return RedirectToAction("Index", "User2");
        //}
    }
}
