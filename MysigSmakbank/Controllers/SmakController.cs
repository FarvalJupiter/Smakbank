using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MysigSmakbank.Models.Entities;
using MysigSmakbank.Models.ViewModels;
using MysigSmakbank.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var smaker = _smakRepo.GetAllSmak();
            return View("BrowseSmak", smaker);
        }

        // GET: Smak/Details/5
        public async Task<IActionResult> Details(System.Guid id)
        {
            var smaker = _smakRepo.GetAllSmak();

            return View("ViewSmak", smaker.FirstOrDefault(s=>s.Id==id));
        }

        // GET: Smak/Create
        public async Task<IActionResult> Create()
        {
            return View("RegisterSmak", new BeverageViewModel());
        }

        // POST: Smak/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeverageViewModel collection)
        {
            try
            {
                if (collection.Model.Id == Guid.Empty)
                {
                    _smakRepo.CreateSmak(collection.Model);
                }
                else
                {

                    EditContent(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("RegisterSmak");
            }
        }

        // GET: Smak/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var smaker = _smakRepo.GetAllSmak();
            return View("RegisterSmak", new BeverageViewModel {Model= smaker.FirstOrDefault(s => s.Id == id) });
        }


    
        public void EditContent(BeverageViewModel collection)
        {
          
                _smakRepo.EditSmak(collection.Model);

        }
    }
}