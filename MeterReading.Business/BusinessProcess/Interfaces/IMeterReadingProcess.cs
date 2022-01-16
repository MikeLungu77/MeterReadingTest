using MeterReading.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading.Business.Interfaces
{
    public interface IMeterReadingProcess
    {
        public Task<ProcessResult> LoadCsvContent(string contentBody);
    }
}
