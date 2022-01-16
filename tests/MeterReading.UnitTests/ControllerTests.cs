using MeterReading.Business.Interfaces;
using MeterReading.Business.Models;
using MeterReading.Controllers;
using MeterReading.Services;
using MeterReading.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MeterReading.UnitTests
{
    [TestClass]
    public class ControllerTests
    {
        private Mock<IMeterReadingService> _serviceMock = new Mock<IMeterReadingService>();
        private Mock<ILogger<MeterReadingController>> _loggerMock = new Mock<ILogger<MeterReadingController>>();

        private MeterReadingController _controller;

        [SetUp]
        public void Setup()
        {

            _serviceMock.
                Setup(x => x.LoadCsvContent("non empty content")).
                Returns(Task.FromResult(new ProcessResult { FailCount= 8, SuccessCount= 27}));

            _controller = new MeterReadingController(_serviceMock.Object, _loggerMock.Object);

        }

        [Test]
        public void LoadCsvContent_ReturnsSuccess()
        {
            SetUpHttpContext("some non empty context");

            var response = _controller.Post(new System.Threading.CancellationToken()).Result;
            Assert.IsNotNull(response);
        }

        [Test]
        [ExpectedException(typeof(BadHttpRequestException))]
        public void LoadCsvContent_ThrowsExceptionWhenContentEmpty()
        {
            SetUpHttpContext("");

            var response = _controller.Post(new System.Threading.CancellationToken()).Result;
        }

        private void SetUpHttpContext(string context)
        {
            var httpContext = new DefaultHttpContext();

            // Create the stream to house our content
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(context));
            httpContext.Request.Body = stream;
            httpContext.Request.ContentLength = stream.Length;
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = httpContext;
        }
    }
}