using System;
using Xunit;
using NSubstitute;
using AutoMapper;
using FluentAssertions;
using ABC_Pharmacy.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace UnitTests
{
    public class PharmacyControllerTest
    {
        private readonly IMapper _mapper;
        private PharmacyController _mockController;
        private readonly ILogger<PharmacyController> _logger;
        private readonly HttpContext _httpContext;

        public PharmacyControllerTest()
        {
            _logger = Substitute.For<Logger<PharmacyController>>();
            _mapper = Substitute.For<IMapper>();
            _httpContext = Substitute.For<HttpContext>();
        }
        [Fact]
        public void Controller_Constructor_Success()
        {
            // Act
            _mockController = GetController();
            _mockController.GetList();
            // Assert
            _mockController.Ok();
        }

        private PharmacyController GetController()
        {
            return new PharmacyController(
               _logger)
            {
                ControllerContext =
                {
                    HttpContext = _httpContext
                }
            };
        }
    }
}
