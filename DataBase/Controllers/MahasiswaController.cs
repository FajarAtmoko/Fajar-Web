using DataBase.Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplikasiSederhana.Controllers
{
    [Authorize]
    public class MahasiswaController : Controller
    {
        public ActionResult Index()
        {
            //Mengambil Data Dari Tabel Mahasiswa
            List<Mahasiswa> r;
            using (var s = new SIMModel())
            {
                r = s.Mahasiswas.ToList();
            }
            return View(r);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                s.Mahasiswas.Add(model);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult index()
        {
            List<Mahasiswa> r;
            using (var s = new SIMModel())
            {
                r = s.Mahasiswas.ToList();
            }
            return View(r);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                model = s.Mahasiswas.Where(x => x.NIM == nim).FirstOrDefault();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                var m = s.Mahasiswas.Where(x => x.NIM == nim).FirstOrDefault();
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                model = s.Mahasiswas.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                model = s.Mahasiswas.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string nim)
        {
            var model = new Mahasiswa();
            TryUpdateModel(model);
            using (var s = new SIMModel())
            {
                var m = s.Mahasiswas.Remove(s.Mahasiswas.FirstOrDefault(x => x.NIM == nim));
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
