using System.ComponentModel.DataAnnotations;

namespace MobileMekaniko_Invoice.Models.Entities
{
    public class tblCar
    {
        [Key]
        public int CarId { get; set; }
        public required string CarRego { get; set; }
        
        // Connection to CarMake
        public ICollection<tblCarManufacturer>? tblCarManufacturer { get; set; }

        public string? CarModel { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }
        public tblCustomer? tblCustomer { get; set; }
    }
}
