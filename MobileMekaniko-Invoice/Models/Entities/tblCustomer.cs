using System.ComponentModel.DataAnnotations;

namespace MobileMekaniko_Invoice.Models.Entities
{
    public class tblCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? PaymentStatus { get; set; }

        // Forgot to add this column in the table
        public string? CustomerNumber { get; set; }
        public ICollection<tblCar>? tblCar { get; set; }
    }
}
