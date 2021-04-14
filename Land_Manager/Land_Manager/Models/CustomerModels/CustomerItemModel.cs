namespace Land_Manager.Models.CustomerModels
{
    public class CustomerItemModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfRenting { get; set; }
        public double Debt { get; set; }
    }
}
