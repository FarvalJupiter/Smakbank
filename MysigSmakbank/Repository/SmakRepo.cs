using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MysigSmakbank.Models.Entities;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace MysigSmakbank.Repository
{
    public class SmakRepo : ISmakRepo
    {
        public void CreateSmak(BeverageBase collection)
        {
            collection.Id = Guid.NewGuid();
            try
            {
                var json = System.IO.File.ReadAllText(@"C:\temp\smak.txt");
                var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(json);
                if (smaker == null)
                {
                    smaker = new List<BeverageBase>();
                }
                smaker.Add(collection);
                using (StreamWriter file = File.CreateText(@"C:\temp\smak.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, smaker);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void EditSmak(BeverageBase collection)
        {
            try
            {
                var json = System.IO.File.ReadAllText(@"C:\temp\smak.txt");
                var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(json);
                if (smaker == null)
                {
                    smaker = new List<BeverageBase>();
                }
                smaker.First(s => s.Id == collection.Id).Grapes = collection.Grapes;
                smaker.First(s => s.Id == collection.Id).Name = collection.Name;
                smaker.First(s => s.Id == collection.Id).OtherNotes = collection.OtherNotes;
                smaker.First(s => s.Id == collection.Id).Producer = collection.Producer;
                smaker.First(s => s.Id == collection.Id).SelectedProductionYear = collection.SelectedProductionYear;
                smaker.First(s => s.Id == collection.Id).SelectedPurchaseYear = collection.SelectedPurchaseYear;
                smaker.First(s => s.Id == collection.Id).Taste = collection.Taste;
                smaker.First(s => s.Id == collection.Id).CountAtHome = collection.CountAtHome;
                smaker.First(s => s.Id == collection.Id).Country = collection.Country;
                smaker.First(s => s.Id == collection.Id).Fragrance = collection.Fragrance;
                using (StreamWriter file = File.CreateText(@"C:\temp\smak.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, smaker);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeverageBase> GetAllSmak()
        {
            var json = System.IO.File.ReadAllText(@"C:\temp\smak.txt");
            var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(json);
            return smaker;
        }
    }
}
