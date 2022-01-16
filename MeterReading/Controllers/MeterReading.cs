using MeterReading.Business.Models;
using MeterReading.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeterReading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {
        private readonly ILogger<MeterReadingController> _logger;
        private readonly IMeterReadingService _service;

        public MeterReadingController(IMeterReadingService service, ILogger<MeterReadingController> logger)
        {
            _service = service ?? throw new ArgumentNullException();
            _logger = logger;
        }

        /// <summary>
        /// Uploads a new MeterReading CSV file.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>ProcessResult</returns>
        [HttpPost("meter-reading-uploads")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Consumes("text/csv")]
        public async Task<ActionResult<ProcessResult>> Post(CancellationToken cancellationToken)
        {
            var bodyStream = new StreamReader(HttpContext.Request.Body);
            var bodyText = await bodyStream.ReadToEndAsync();
            return await _service.LoadCsvContent(bodyText);
        }
    }
}