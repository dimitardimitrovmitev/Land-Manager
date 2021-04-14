namespace Land_Manager.Models.PaymentsModels
{
    public class PaymentItemModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Cost { get; set; }
        public string Date { get; set; }
    }
}
