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
        private readonly IServiceRepository<Parcel> _repository;

        public ParcelController(IServiceRepository<Parcel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        public Parcel Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        public ActionResult Create(Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(parcel);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(parcel);
        }



        [HttpPost]
        public ActionResult Update(Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(parcel);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(parcel);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
