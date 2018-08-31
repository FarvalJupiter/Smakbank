using Microsoft.AspNetCore.Mvc.Rendering;
using MysigSmakbank.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MysigSmakbank.Models.ViewModels
{
    public class BeverageViewModel
    {
        public BeverageViewModel()
        {
            ProductionYear = new SelectList(Enumerable.Range(2000, (DateTime.Now.Year - 2000) + 1));
            PurchaseYear = new SelectList(Enumerable.Range(2000, (DateTime.Now.Year - 2000) + 1));
        }

        public BeverageBase Model { get; set; }
        public IEnumerable<SelectListItem> PurchaseYear { get; set; }
        public IEnumerable<SelectListItem> ProductionYear { get; set; }


    }
}
