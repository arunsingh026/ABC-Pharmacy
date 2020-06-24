using System;
using Xunit;
using NSubstitute;
using AutoMapper;
using FluentAssertions;
using ABC_Pharmacy.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ABC_Pharmacy.DataAccess;

namespace UnitTests
{
    public class PharmacyControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private PharmacyController _mockController;
        private readonly ILogger<PharmacyController> _logger;
        private readonly HttpContext _httpContext;

        public PharmacyControllerTest()
        {
            _logger = Substitute.For<Logger<PharmacyController>>();
            _mapper = Substitute.For<IMapper>();
            _repository = Substitute.For<IRepository>();
            _httpContext = Substitute.For<HttpContext>();
        }
        [Fact]
        public void Controller_Constructor_Success()
        {
            PharmacyController ph = GetController();
            ph.GetList();
        }

        private PharmacyController GetController()
        {
            return new PharmacyController(
               _logger,
               _repository)
            {
                ControllerContext =
                {
                    HttpContext = _httpContext
                }
            };
        }
    }
}
