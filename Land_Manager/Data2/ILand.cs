using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
namespace Data
{
    public interface ILand
    {
        void Add(Land land);
        void Update(Land land);
        Land Get(int id);
        IEnumerable<Land> GetAll();
        int GetNumberOfLands();
    }
}
