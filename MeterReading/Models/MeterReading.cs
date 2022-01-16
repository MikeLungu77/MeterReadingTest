using System.ComponentModel.DataAnnotations;

namespace MeterReading.Models
{
    public class MeterReading
    {
        [Required]
        public int AccountId { get; set; }
        
        [Required]
        public DateTime MeterReadingDateTime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string MeaterReadingValue { get; set; } = string.Empty;
    }
}
