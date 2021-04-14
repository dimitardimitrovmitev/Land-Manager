using System.Collections.Generic;

namespace Land_Manager.Models
{
    public class HomeViewModel
    {
        public int CustomerCount { get; set; }
        public int LandCount { get; set; }
        public double RentCollectedThisMonth { get; set; }
        public IEnumerable<PaymentsModels.PaymentItemModel> PaymentsThisMonth { get; set; }
    }
}
