using MEKANIKO_FINAL_INVOICE.Models.Dto;
using MEKANIKO_FINAL_INVOICE.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MEKANIKO_FINAL_INVOICE.Controllers
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
            var customer = await _customerRepository.GetCustomerListAsync();
            return View(customer);
        }

        // POST - Add New Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewCustomer([FromBody] AddCustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.AddCustomerAsync(dto);
                return Json(new { success = true, message = "Customer Added Successfully!" });
            }

            return Json(new { success = false, message = "Failed to add customer." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = "Invalid customer ID." });
            }

            try
            {
                var result = await _customerRepository.DeleteCustomerByIdAsync(id);
                if (result)
                {
                    return Json(new { success = true, message = "Customer deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Customer not found." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error occurred while deleting customer: {ex.Message}" });
            }
        }


    }
}
