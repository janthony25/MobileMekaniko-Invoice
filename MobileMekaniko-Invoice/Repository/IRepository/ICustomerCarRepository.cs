using MobileMekaniko_Invoice.Models.Dto;

namespace MobileMekaniko_Invoice.Repository.IRepository
{
    public interface ICustomerCarRepository
    {
        Task<List<CustomerCarDto>> GetCustomerCarsByIdAsync(int id);
    }
}
