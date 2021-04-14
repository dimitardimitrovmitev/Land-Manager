namespace Land_Manager.Models.CustomerModels
{
    public class CustomerIndexModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string DateOfRenting { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double MoneyOwed { get; set; }
    }
}
