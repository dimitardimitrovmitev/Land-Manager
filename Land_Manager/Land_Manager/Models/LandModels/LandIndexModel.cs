using System.Collections.Generic;

namespace Land_Manager.Models.LandModels
{
    public class LandIndexModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public double Rent { get; set; }
        public IEnumerable<CustomerModels.CustomerItemModel> Customers { get; set; }
    }
}
