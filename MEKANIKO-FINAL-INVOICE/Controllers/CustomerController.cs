using MEKANIKO_FINAL_INVOICE.Models.Dto;
using MEKANIKO_FINAL_INVOICE.Repository;
using MEKANIKO_FINAL_INVOICE.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MEKANIKO_FINAL_INVOICE.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        public CustomerController(ICustomerRepository customerRepository, ICarRepository carRepository)
        {
            _customerRepository = customerRepository;
            _carRepository = carRepository;
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

        // POST - Delete Customer
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

        // GET - Customer Cars
        public async Task<IActionResult> GetCustomerCars(int id)
        {
            var customerCar = await _customerRepository.GetCustomerCarsByIdAsync(id);
            var makes = await _carRepository.GetAllMakesAsync();
            ViewBag.Makes = makes;
            return View(customerCar);
        }


    }
}
