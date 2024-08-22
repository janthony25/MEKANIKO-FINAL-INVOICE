using MEKANIKO_FINAL_INVOICE.Models.Dto;

namespace MEKANIKO_FINAL_INVOICE.Repository.IRepository
{
    public interface IInvoiceRepository
    {
        Task AddInvoiceToCarAsync(AddCarInvoiceDto dto);
        Task<InvoiceDetailsDto> GetInvoiceDetailsAsync(int id);
    }
}
