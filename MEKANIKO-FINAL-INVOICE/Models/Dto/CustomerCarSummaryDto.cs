namespace MEKANIKO_FINAL_INVOICE.Models.Dto
{
    public class CustomerCarSummaryDto
    {
        public int CustomerId { get; set; }
        public  string CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public bool? PaymentStatus { get; set; }
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public bool? CarPaymentStatus { get; set; }
        public  string MakeName { get; set; }
    }
}
