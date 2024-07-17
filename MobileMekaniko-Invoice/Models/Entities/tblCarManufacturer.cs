namespace MobileMekaniko_Invoice.Models.Entities
{
    public class tblCarManufacturer
    {
        public int CarId { get; set; }
        public tblCar? tblCar { get; set; }
        public int CarMakeId { get; set; }
        public tblCarMake? tblCarMake { get; set; }
    }
}
