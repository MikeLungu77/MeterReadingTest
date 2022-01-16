using MeterReading.Business.Validation.Interfaces;
using MeterReading.Data.Models;
using System.Text.RegularExpressions;

namespace MeterReading.Business.Validation
{
    public static class MeterReadingValidation // : IMeterReadingValidation
    {
        public static bool IsValid(this string[] input)
        {
            try
            {
                if (input.Count() != 3)
                    return false;
                if( !Regex.IsMatch(input[2], "^[0-9]{5}$"))
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static MeterReadingDto ToMeterReadingDto(this string[] input)
        {
            MeterReadingDto result = new MeterReadingDto();
            result.AccountId = int.Parse(input[0]);
            result.ReadingDateTime = DateTime.Parse(input[1]);
            result.ReadingValue = input[2];
            return new MeterReadingDto();
        }
    }
}