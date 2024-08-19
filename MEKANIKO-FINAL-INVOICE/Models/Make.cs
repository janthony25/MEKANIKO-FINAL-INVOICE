using System.ComponentModel.DataAnnotations;

namespace MEKANIKO_FINAL_INVOICE.Models
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }
        public required string MakeName { get; set; }

        // M-to-M Car-Make
        public List<CarMake> CarMake { get; set; }
    }
}
