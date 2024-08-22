namespace MEKANIKO_FINAL_INVOICE.Models.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public bool? CarPaymentStatus { get; set; }
        public List<MakeDto> MakeName { get; set; }
    }
}
