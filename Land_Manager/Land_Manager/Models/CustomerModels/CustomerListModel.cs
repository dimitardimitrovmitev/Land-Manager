using System.Collections.Generic;

namespace Land_Manager.Models.CustomerModels
{
    public class CustomerListModel
    {
        public IEnumerable<CustomerItemModel> Customers { get; set; }
    }
}
