using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_Test_Service.Model;

namespace Web_API_Test_Service.Controllers
{
    public class ParcelController : Controller
    {
        private IServiceRepository<Parcel> _repository;

        public ParcelController(IServiceRepository<Parcel> repository)
        {
            _repository = repository;
        }

        // GET: ParcelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParcelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParcelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParcelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParcelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParcelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParcelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParcelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
