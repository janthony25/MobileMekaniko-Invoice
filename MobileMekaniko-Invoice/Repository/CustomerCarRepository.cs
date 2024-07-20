using Microsoft.EntityFrameworkCore;
using MobileMekaniko_Invoice.Data;
using MobileMekaniko_Invoice.Models.Dto;
using MobileMekaniko_Invoice.Repository.IRepository;

namespace MobileMekaniko_Invoice.Repository
{
    public class CustomerCarRepository : ICustomerCarRepository
    {
        private readonly DataContext _data;
        public CustomerCarRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<List<CustomerCarDto>> GetCustomerCarsByIdAsync(int id)
        {

            // ---- CAN ONLY BE USED IF THERE ARE CARS REGISTERED TO THE CUSTOMER ALREADY ----
            //var customerCars = await _data.tblCar
            //    .Include(car => car.tblCustomer)
            //    .Include(car => car.tblCarManufacturer)
            //        .ThenInclude(cm => cm.tblCarMake)
            //    .Where(car => car.CustomerId == id)
            //    .Select(car => new CustomerCarDto
            //    {
            //        CustomerId = car.CustomerId,
            //        CustomerName = car.tblCustomer.CustomerName,
            //        CustomerEmail = car.tblCustomer.CustomerEmail,
            //        CarRego = car.CarRego,
            //        CarMakeName = car.tblCarManufacturer.Select(cm => cm.tblCarMake.CarMakeName).FirstOrDefault(),
            //        CarModel = car.CarModel
            //    }).ToListAsync();

            //        return customerCars;
            //    }


            // WORKS EVEN IF THERE ARE NO CARS ADDED YET
            var customerCars = await _data.tblCustomer
                .Where(c => c.CustomerId == id)
                .GroupJoin(
                    _data.tblCar
                    .Include(car => car.tblCarManufacturer)
                    .ThenInclude(cm => cm.tblCarMake),
                        customer => customer.CustomerId,
                        car => car.CustomerId,
                        (customer, cars) => new { customer, cars }
                )
                .SelectMany(
                    x => x.cars.DefaultIfEmpty(), // Ensures that customers with no cars are included
                    (x, car) => new CustomerCarDto
                        {
                            CustomerId = x.customer.CustomerId,
                            CustomerName = x.customer.CustomerName,
                            CustomerEmail = x.customer.CustomerEmail,
                            CarRego = car != null ? car.CarRego : null,
                            CarMakeName = car != null ? car.tblCarManufacturer.Select(cm => cm.tblCarMake.CarMakeName).FirstOrDefault() : null,
                            CarModel = car != null ? car.CarModel : null
                        }
                    )
                    .ToListAsync();

                        return customerCars;
        }

    }
}

