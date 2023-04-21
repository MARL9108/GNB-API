using Castle.Core.Logging;
using FluentAssertions;
using GNB_API.Controllers;
using GNB_Data.Response;
using GNB_Service.Services;
using GNB_Test.MockData;
using GNB_Test.MockData.Request;
using GNB_Test.MockData.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Test.System.Controllers
{
    public class TestGNBController
    {
        [Fact]
        public async Task GetAllConversionRates_GoodResponse()
        {
            //Arrange
            var conversionRateService = new Mock<IConversionRate>();
            conversionRateService.Setup(_ => _.GetConversionRates()).ReturnsAsync(RateMockData.GetRateList());
            var sut = new GNBController(conversionRateService.Object, null, null);

            ///Act
            var result = await sut.GetAllConversionRates();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAllConversionRates_BadResponse()
        {
            //Arrange
            var conversionRateService = new Mock<IConversionRate>();
            conversionRateService.Setup(_ => _.GetConversionRates()).ReturnsAsync(RateMockData.GetEmptyRates());
            var sut = new GNBController(conversionRateService.Object, null, null);

            ///Act
            var result = await sut.GetAllConversionRates();

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task GetAllConversionRates_ExceptionResponse()
        {
            //Arrange
            var conversionRateService = new Mock<IConversionRate>();
            var logger = new Mock<ILogger<GNBController>>();
            conversionRateService.Setup(_ => _.GetConversionRates()).ThrowsAsync(new Exception("Error geeting rates"));
            var sut = new GNBController(conversionRateService.Object, null, logger.Object);

            ///Act
            var result = await sut.GetAllConversionRates();

            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);            
        }
        [Fact]
        public async Task GetAllTransaction_GoodResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            transactionService.Setup(_ => _.GetAllTransactions()).ReturnsAsync(TransactionMockData.GetTransacionList());
            var sut = new GNBController(null, transactionService.Object, null);

            ///Act
            var result = await sut.GetAllTransactions();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAllTransaction_BadResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            transactionService.Setup(_ => _.GetAllTransactions()).ReturnsAsync(TransactionMockData.GetEmptyTransacion());
            var sut = new GNBController(null, transactionService.Object, null);

            ///Act
            var result = await sut.GetAllTransactions();

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task GetAllTransaction_ExceptionResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            var logger = new Mock<ILogger<GNBController>>();
            transactionService.Setup(_ => _.GetAllTransactions()).ThrowsAsync(new Exception("Error geeting transactions"));
            var sut = new GNBController(null, transactionService.Object, logger.Object);

            ///Act
            var result = await sut.GetAllTransactions();

            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task GetTransactionBySku_GoodResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            var mockData = new TransactionRequestMockData();
            transactionService.Setup(_ => _.GetTransaction(mockData.transactionRequest)).Returns(TransactionResponseMockData.GetTransactionBySku(mockData.transactionRequest.Sku));
            var sut = new GNBController(null, transactionService.Object, null);

            ///Act
            var result = sut.GetTransaction(mockData.transactionRequest);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetTransactionBySku_BadResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            var mockData = new TransactionRequestMockData();
            transactionService.Setup(_ => _.GetTransaction(mockData.transactionRequest)).Returns(TransactionResponseMockData.GetTransactionEmpty());
            var sut = new GNBController(null, transactionService.Object, null);

            ///Act
            var result = sut.GetTransaction(mockData.transactionRequest);

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
        [Fact]
        public async Task GetTransactionBySku_ExceptionResponse()
        {
            //Arrange
            var transactionService = new Mock<ITransaction>();
            var mockData = new TransactionRequestMockData();
            var logger = new Mock<ILogger<GNBController>>();
            transactionService.Setup(_ => _.GetTransaction(mockData.transactionRequest)).Throws(new Exception("Transaction not founded"));
            var sut = new GNBController(null, transactionService.Object, logger.Object);

            ///Act
            var result = sut.GetTransaction(mockData.transactionRequest);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
            (result as BadRequestResult).StatusCode.Should().Be(400);
        }
    }
}
