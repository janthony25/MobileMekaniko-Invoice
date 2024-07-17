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
            var customerCars = await _data.tblCar
                .Include(car => car.tblCustomer)
                .Include(car => car.tblCarManufacturer)
                    .ThenInclude(cm => cm.tblCarMake)
                .Where(car => car.CustomerId == id)
                .Select(car => new CustomerCarDto
                {
                    CustomerId = car.CustomerId,
                    CustomerName = car.tblCustomer.CustomerName,
                    CustomerEmail = car.tblCustomer.CustomerEmail,
                    CarRego = car.CarRego,
                    CarMakeName = car.tblCarManufacturer.Select(cm => cm.tblCarMake.CarMakeName).FirstOrDefault(),
                    CarModel = car.CarModel
                }).ToListAsync();

                    return customerCars;
                }
        }

}

