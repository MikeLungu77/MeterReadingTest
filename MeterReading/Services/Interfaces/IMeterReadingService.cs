using MeterReading.Business.Models;

namespace MeterReading.Services.Interfaces
{
    public interface IMeterReadingService
    {
        public Task<ProcessResult> LoadCsvContent(string? contentBody = null);
    }
}
