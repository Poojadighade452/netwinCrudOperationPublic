using Microsoft.AspNetCore.Mvc;
using netwinCrudOperation.Models;
using System.Diagnostics;

namespace netwinCrudOperation.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly SchoolDBContext _db;
        public HomeController(SchoolDBContext db)
        {

            _db = db;
        }

        public IActionResult Index()
        {
            var result = _db.schools.ToList();
            SchoolVM vm = new SchoolVM();
            vm.Schools = result;
            return View(vm);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Created(SchoolVM model)
        {
            if (model.SchoolObj != null)
            {
                _db.schools.Add(model.SchoolObj);
                _db.SaveChanges();
                TempData["success"] = "School inserted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _db.schools.Find(id);
            return View(result);
        }
       

        [HttpPost]
        public IActionResult Edited(SchoolVM model)
        {
            if (ModelState.IsValid)
            {
                _db.schools.Update(model.SchoolObj);
                _db.SaveChanges();
                TempData["success"] = "School Update successfully";
                return RedirectToAction("Sample");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var res = _db.schools.Find(id);
                return View(res);
            }
            return View();
        }
        //[HttpPost, ActionName("Delete")]
        //public IActionResult Deleted(int id)
        //{
        //    if (id > 0)
        //    {
        //        var res = _db.schools.Find(id);
        //        _db.Remove(res);
        //        _db.SaveChanges();
        //        TempData["success"] = "School deleted successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Deletede(int id)
        {
            if (id > 0)
            {
                var res = _db.schools.Find(id);
                _db.Remove(res);
                _db.SaveChanges();
                TempData["success"] = "School deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}