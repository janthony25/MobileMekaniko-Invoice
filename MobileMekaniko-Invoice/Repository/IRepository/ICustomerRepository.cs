using MobileMekaniko_Invoice.Models.Dto;

namespace MobileMekaniko_Invoice.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerSummaryDto>> GetCustomerSummaryAsync();

        Task AddNewCustomerAsync(AddCustomerDto customerDto);
    }
}
