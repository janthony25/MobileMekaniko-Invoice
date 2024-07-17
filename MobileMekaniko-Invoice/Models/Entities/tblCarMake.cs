using System.ComponentModel.DataAnnotations;

namespace MobileMekaniko_Invoice.Models.Entities
{
    public class tblCarMake
    {
        [Key]
        public int CarMakeId { get; set; }
        public required string CarMakeName { get; set; }

        public ICollection<tblCarManufacturer>? tblCarManufacturer { get; set; }

    }
}
