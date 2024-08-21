using MEKANIKO_FINAL_INVOICE.Data;
using MEKANIKO_FINAL_INVOICE.Models;
using MEKANIKO_FINAL_INVOICE.Models.Dto;
using MEKANIKO_FINAL_INVOICE.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MEKANIKO_FINAL_INVOICE.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;
        public CustomerRepository(DataContext data)
        {
            _data = data;
        }

        public async Task AddCustomerAsync(AddCustomerDto dto)
        {
            var customer = new Customer
            {
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                CustomerNumber = dto.CustomerNumber
            };

            _data.Customers.Add(customer);
            await _data.SaveChangesAsync();
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            var customer = await _data.Customers.FindAsync(id);
            if (customer != null)
            {
                _data.Customers.Remove(customer);
                await _data.SaveChangesAsync();
                return true;  // Deletion was successful
            }
            return false;  // Customer not found
        }

        public async Task<List<CustomerSummaryDto>> GetCustomerListAsync()
        {
            return await _data.Customers
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
