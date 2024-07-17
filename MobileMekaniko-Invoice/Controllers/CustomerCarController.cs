using Microsoft.AspNetCore.Mvc;
using MobileMekaniko_Invoice.Repository.IRepository;

namespace MobileMekaniko_Invoice.Controllers
{
    public class CustomerCarController : Controller
    {
        private readonly ICustomerCarRepository _customerCarRepository;

        public CustomerCarController(ICustomerCarRepository customerCarRepository)
        {
            _customerCarRepository = customerCarRepository;
        }

        // GET - Customer's Car List
        public async Task<IActionResult> GetCustomerCar(int id)
        {
            var customerCar = await _customerCarRepository.GetCustomerCarsByIdAsync(id);
            if (customerCar == null || !customerCar.Any())
            {
                return NotFound();
            }
            return View(customerCar);
        }
    }
}
