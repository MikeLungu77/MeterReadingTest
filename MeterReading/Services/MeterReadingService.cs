using MeterReading.Business.Interfaces;
using MeterReading.Business.Models;
using MeterReading.Services.Interfaces;

namespace MeterReading.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly ILogger _logger;
        private readonly IMeterReadingProcess _meterReadingProcess;
        public MeterReadingService(IMeterReadingProcess meterReadingProcess, ILogger<MeterReadingService> logger)
        {
            _meterReadingProcess = meterReadingProcess;
            _logger = logger;
        }
        public async Task<ProcessResult> LoadCsvContent(string? contentBody = null)
        {

            if (string.IsNullOrEmpty(contentBody))
                throw new BadHttpRequestException("Invalid Csv File provided");
            return await _meterReadingProcess.LoadCsvContent(contentBody?? "");
        }
    }
}
