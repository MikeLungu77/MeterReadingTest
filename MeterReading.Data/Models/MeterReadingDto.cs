using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterReading.Data.Models
{
    [Table("MeterReading", Schema = "dbo")]
    [Index(nameof(AccountId), nameof(ReadingDateTime), nameof(ReadingValue), 
        IsUnique = true, Name = "UX_MeterReading_AccountId_ReadingDateTime_ReadingValue")]
    public class MeterReadingDto
    {
        [Required]
        public int AccountId { get; set; }
        
        [Required]
        public DateTime ReadingDateTime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ReadingValue { get; set; } = string.Empty;

        public virtual AccountDto Account { get; set; }
    }
}
