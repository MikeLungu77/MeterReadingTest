using MeterReading.Business.Interfaces;
using MeterReading.Business.Models;
using MeterReading.Business.Validation;
using MeterReading.Data;
using MeterReading.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading.Business.BusinessProcess
{
    public class MeterReadingProcess : IMeterReadingProcess
    {
        private ProcessResult result = new ProcessResult();
        private MeterReadingDto meterReadingToSave =  new MeterReadingDto();

        private readonly ISqlDbContext _dbContext;

        public MeterReadingProcess(ISqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProcessResult> LoadCsvContent(string contentBody)
        {
            string[] lines = contentBody.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
            var csv = (from line in lines
                       select line.Split(','));
            foreach (var line in csv)
            {
                if (line.IsValid())
                {
                    meterReadingToSave = line.ToMeterReadingDto();
                    try
                    {
                        //await _dbContext.MeterReadingDto.AddAsync(meterReadingToSave);
                        //await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        result.FailCount++;
                    }
                    result.SuccessCount++;
                    //await DB save operation
                }
                else
                    result.FailCount++;
            }

            return result;
        }
    }
}
