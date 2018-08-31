using MysigSmakbank.Models.Entities;
using System.Collections.Generic;

namespace MysigSmakbank.Repository
{
    public interface ISmakRepo
    {

        void CreateSmak(BeverageBase collection);

        List<BeverageBase> GetAllSmak();
        void EditSmak(BeverageBase collection);
    }
}