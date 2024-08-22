using MEKANIKO_FINAL_INVOICE.Data;
using MEKANIKO_FINAL_INVOICE.Models;
using MEKANIKO_FINAL_INVOICE.Models.Dto;
using MEKANIKO_FINAL_INVOICE.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MEKANIKO_FINAL_INVOICE.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _data;
        public CarRepository(DataContext data)
        {
            _data = data;
        }
        // ----------------- CALUDE CODE ----------------------
        public async Task<bool> AddCarToCustomerAsync(AddCarDto dto)
        {
            // Get the customer
            var customer = await _data.Customers.FindAsync(dto.CustomerId);

            // Create a new car
            var car = new Car
            {
                CarRego = dto.CarRego,
                CarModel = dto.CarModel,
                CarYear = dto.CarYear,
                CustomerId = customer.CustomerId
            };

            // Add Car to Db
            _data.Cars.Add(car);

            // Save Changes to Db
            await _data.SaveChangesAsync();

            // Find Make
            var make = await _data.Makes.FindAsync(dto.MakeId);

            // Create New CarMake   
            var carMake = new CarMake
            {
                CarId = car.CarId,
                MakeId = make.MakeId
            };

            // Add CarMake to Db
            _data.CarMakes.Add(carMake);

            // Save Changes to Db
            await _data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCarByIdAsync(int id)
        {
            var car = await _data.Cars.FindAsync(id);
            if(car != null)
            {
                _data.Cars.Remove(car);
                await _data.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<MakeDto>> GetAllMakesAsync()
        {
            var makes = await _data.Makes.Select(m => new MakeDto
            {
                MakeId = m.MakeId,
                MakeName = m.MakeName
            }).ToListAsync();

            return makes;
        }




    }
}
