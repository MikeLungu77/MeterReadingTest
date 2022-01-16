using MeterReading.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterReading.Data
{
    public interface ISqlDbContext
    {
        DbSet<AccountDto> AccountDto { get; }
        DbSet<MeterReadingDto> MeterReadingDto { get; }
    }
}
