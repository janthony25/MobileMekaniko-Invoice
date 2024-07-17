using Microsoft.AspNetCore.Mvc;
using MobileMekaniko_Invoice.Models.Dto;
using MobileMekaniko_Invoice.Repository.IRepository;

namespace MobileMekaniko_Invoice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        

        // GET - Customer List
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerRepository.GetCustomerSummaryAsync();
            return View(customer);
        }

        public IActionResult AddNewCustomer()
        {
            return View();
        }

        // POST - Add Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewCustomer(AddCustomerDto customerDto)
        {
            if(ModelState.IsValid)
            {
                 await _customerRepository.AddNewCustomerAsync(customerDto);
                return RedirectToAction("GetCustomerList");
            }
            return View(customerDto);
        }
    }
}
