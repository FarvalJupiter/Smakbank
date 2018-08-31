using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MysigSmakbank.Models.Entities
{
    public class BeverageBase
    {
        //public BeverageBase()
        //{
        //    ProductionYear = new SelectList(Enumerable.Range(2000, (DateTime.Now.Year - 2000) + 1));
        //    PurchaseYear = new SelectList(Enumerable.Range(2000, (DateTime.Now.Year - 2000) + 1));
            
        //}
        public Guid Id { get; set; }
        public Group Type { get; set; }
        public List<Grape> Grapes { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public int SelectedProductionYear { get; set; }
        //public IEnumerable<SelectListItem> ProductionYear { get; set; }
        public string Country { get; set; }
        public string Taste { get; set; }
        public string Fragrance { get; set; }
        public string OtherNotes { get; set; }
        public int SelectedPurchaseYear { get; set; }
        //public IEnumerable<SelectListItem> PurchaseYear { get; set; }
        public int CountAtHome { get; set; }

    }
}
