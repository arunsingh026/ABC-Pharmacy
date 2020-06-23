namespace ABC_Pharmacy.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using ABC_Pharmacy.DataAccess;
    using ABC_Pharmacy.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<PharmacyController> _logger;

        public PharmacyController(ILogger<PharmacyController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Medicine> GetList()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IActionResult AddMedicine(Medicine medicine)
        {
            var isSuccess = _repository.Add(medicine);
            return Ok(isSuccess);
        }

        [HttpPut]
        public IActionResult UpdateMedicine(Medicine medicine)
        {
            var isSuccess = _repository.Update(medicine);
            return Ok(isSuccess);
        }
    }
}
