using Microsoft.EntityFrameworkCore;
using MobileMekaniko_Invoice.Data;
using MobileMekaniko_Invoice.Models.Dto;
using MobileMekaniko_Invoice.Models.Entities;
using MobileMekaniko_Invoice.Repository.IRepository;

namespace MobileMekaniko_Invoice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;

        public CustomerRepository(DataContext data)
        {
            _data = data;
        }

        public async Task AddNewCustomerAsync(AddCustomerDto customerDto)
        {
            var customer = new tblCustomer
            {
                CustomerName = customerDto.CustomerName,
                CustomerEmail = customerDto.CustomerEmail,
                CustomerNumber = customerDto.CustomerNumber,
            };

                _data.tblCustomer.AddAsync(customer);
                await _data.SaveChangesAsync();

                
        }

        public async Task DeleteCustomerByIdAsync(int customerId)
        {
            var customer = await _data.tblCustomer.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if(customer != null)
            {
                _data.tblCustomer.Remove(customer);
                await _data.SaveChangesAsync();
            }

        }

        public async Task<CustomerSummaryDto> GetCustomerById(int id)
        {
            return await _data.tblCustomer
              .Where(c => c.CustomerId == id)
              .Select(c => new CustomerSummaryDto
              {
                  CustomerId = c.CustomerId,
                  CustomerName = c.CustomerName,
                  CustomerEmail = c.CustomerEmail,
                  CustomerNumber = c.CustomerNumber
              })
              .FirstOrDefaultAsync();
        }

        public async Task<List<CustomerSummaryDto>> GetCustomerSummaryAsync()
        {
            return await _data.tblCustomer
                .Select(c => new CustomerSummaryDto
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    CustomerEmail = c.CustomerEmail,
                    CustomerNumber = c.CustomerNumber
                }).ToListAsync();
        }

       
    }
}
