using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MysigSmakbank.Models.Entities;
using MysigSmakbank.Models.ViewModels;
using MysigSmakbank.Repository;
using System;
using System.Linq;

namespace MysigSmakbank.Controllers
{
    public class SmakController : Controller
    {
        private ISmakRepo _smakRepo;
        public SmakController(ISmakRepo smakRepo)
        {
            _smakRepo = smakRepo;
        }

        // GET: Smak
        public ActionResult Index()
        {
            var smaker = _smakRepo.GetAllSmak();
            return View("BrowseSmak", smaker);
        }

        // GET: Smak/Details/5
        public ActionResult Details(System.Guid id)
        {
            var smaker = _smakRepo.GetAllSmak();

            return View("ViewSmak", smaker.FirstOrDefault(s=>s.Id==id));
        }

        // GET: Smak/Create
        public ActionResult Create()
        {
            return View("RegisterSmak", new BeverageViewModel());
        }

        // POST: Smak/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeverageViewModel collection)
        {
            try
            {
                _smakRepo.CreateSmak(collection.Model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("RegisterSmak");
            }
        }

        // GET: Smak/Edit/5
        public ActionResult Edit(Guid id)
        {
            var smaker = _smakRepo.GetAllSmak();
            return View("RegisterSmak", new BeverageViewModel {Model= smaker.FirstOrDefault(s => s.Id == id) });
        }

        // POST: Smak/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BeverageViewModel collection)
        {
            try
            {
                _smakRepo.EditSmak(collection.Model);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}