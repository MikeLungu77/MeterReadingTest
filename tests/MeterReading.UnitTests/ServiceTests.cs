using MeterReading.Business.Interfaces;
using MeterReading.Business.Models;
using MeterReading.Services;
using MeterReading.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MeterReading.UnitTests
{
    [TestClass]
    public class ServiceTests
    {
        private Mock<IMeterReadingProcess> _processMock = new Mock<IMeterReadingProcess>();
        private Mock<ILogger<MeterReadingService>> _loggerMock = new Mock<ILogger<MeterReadingService>>();

        private MeterReadingService _service;

        [SetUp]
        public void Setup()
        {

            _processMock.
                Setup(x => x.LoadCsvContent("non empty content")).
                Returns(Task.FromResult(new ProcessResult { FailCount= 8, SuccessCount= 27}));

            _service = new MeterReadingService(_processMock.Object, _loggerMock.Object);

        }

        [Test]
        public void LoadCsvContent_ReturnsSuccess()
        {
            var response = _service.LoadCsvContent("non empty content").Result;
            Assert.IsNotNull(response);
        }

    }
}