using Microsoft.AspNetCore.Mvc;
using MobileMekaniko_Invoice.Data;
using MobileMekaniko_Invoice.Models.Dto;
using MobileMekaniko_Invoice.Repository.IRepository;
using System.ComponentModel;

namespace MobileMekaniko_Invoice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly DataContext _data;

        public CustomerController(ICustomerRepository customerRepository, DataContext data)
        {
            _customerRepository = customerRepository;
            _data = data;
        }
        

        // GET - Customer List
        public async Task<IActionResult> GetCustomerList()
        {
            var customer = await _customerRepository.GetCustomerSummaryAsync();
            return View(customer);
        }

        // GET - Add Customer
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

        // GET - Delete Customer
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
          if (id ==  0 || id == null)
            {
                return NotFound();
            }

            var customer = _data.tblCustomer.FindAsync(id);
            return View(customer);
        }

        // POST - Delete Customer
        [HttpPost, DisplayName("DeleteCustomerById")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomerByIdPost(int customerId)
        {
            await _customerRepository.DeleteCustomerByIdAsync(customerId);
            return RedirectToAction("GetCustomerList");
        }
    }
}
