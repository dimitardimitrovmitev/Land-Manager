using System.Collections.Generic;

namespace Land_Manager.Models.PaymentsModels
{
    public class PaymentsFromCustomerListModel
    {
        public IEnumerable<PaymentItemModel> Payments { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
