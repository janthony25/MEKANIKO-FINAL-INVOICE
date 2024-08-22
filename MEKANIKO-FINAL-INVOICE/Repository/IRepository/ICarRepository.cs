using MEKANIKO_FINAL_INVOICE.Models.Dto;

namespace MEKANIKO_FINAL_INVOICE.Repository.IRepository
{
    public interface ICarRepository
    {
        Task<bool> AddCarToCustomerAsync(AddCarDto dto);
        Task<List<MakeDto>> GetAllMakesAsync();
        Task<bool> DeleteCarByIdAsync(int id);
    }
}
