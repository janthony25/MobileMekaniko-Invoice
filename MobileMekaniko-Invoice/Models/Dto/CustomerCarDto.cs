namespace MobileMekaniko_Invoice.Models.Dto
{
    public class CustomerCarDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public required string CarRego { get; set; }
        public required string CarMakeName { get; set; }
        public string? CarModel { get; set; }
    }
}
