using System.ComponentModel.DataAnnotations.Schema;

namespace MeterReading.Data.Models
{
    [Table("Account", Schema = "dbo")]
    public class AccountDto
    {
        public int AccountId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<MeterReadingDto> MeterReadings { get; set; }
    }
}
