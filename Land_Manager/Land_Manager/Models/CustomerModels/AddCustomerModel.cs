using Data.Models;
using System.Collections.Generic;

namespace Land_Manager.Models.CustomerModels
{
    public class AddCustomerModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Land> Lands { get; set; }
        public int RentedLandId { get; set; }
    }
}
