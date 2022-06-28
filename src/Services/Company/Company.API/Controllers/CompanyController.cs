using Company.API.Entities;
using Company.API.Repositories.Interface;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Company.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyRepository repository, ILogger<CompanyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyData>>> GetCompanyDatas()
        {
            var CompanyDatas = await _repository.GetCompanyData();
            return Ok(CompanyDatas);
        }

        

        

        [Route("[action]/{name}", Name = "GetCompanyDataByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<CompanyData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyData>>> GetCompanyDataByName(string name)
        {
            var items = await _repository.GetCompanyDataByName(name);
            if (items == null)
            {
                _logger.LogError($"CompanyDatas with name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }
        [HttpGet("{id:length(24)}", Name = "GetCompanyData")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CompanyData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyData>> GetCompanyDataById(string id)
        {
            var CompanyData = await _repository.GetCompanyData(id);

            if (CompanyData == null)
            {
                _logger.LogError($"CompanyData with id: {id}, not found.");
                return NotFound();
            }

            return Ok(CompanyData);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyData>> CreateCompanyData([FromBody] CompanyData CompanyData)
        {
            await _repository.CreateCompanyData(CompanyData);

            return CreatedAtRoute("GetCompanyData", new { id = CompanyData.Id }, CompanyData);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CompanyData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCompanyData([FromBody] CompanyData CompanyData)
        {
            return Ok(await _repository.UpdateCompanyData(CompanyData));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCompanyData")]
        [ProducesResponseType(typeof(CompanyData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCompanyDataById(string id)
        {
            return Ok(await _repository.DeleteCompanyData(id));
        }
    }
}
