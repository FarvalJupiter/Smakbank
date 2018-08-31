using MysigSmakbank.Models.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MysigSmakbank.Repository
{
    public interface ISmakRepo
    {

        void CreateSmak(BeverageBase collection);

        List<BeverageBase> GetAllSmak();
        void EditSmak(BeverageBase collection);
    }
}