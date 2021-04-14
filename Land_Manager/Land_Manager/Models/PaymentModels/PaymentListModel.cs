using System.Collections.Generic;

namespace Land_Manager.Models.PaymentsModels
{
    public class PaymentListModel
    {
        public IEnumerable<PaymentItemModel> Payments { get; set; }
    }
}
