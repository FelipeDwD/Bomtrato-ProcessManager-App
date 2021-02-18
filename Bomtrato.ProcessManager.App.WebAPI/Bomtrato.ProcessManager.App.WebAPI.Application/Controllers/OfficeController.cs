using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bomtrato.ProcessManager.App.WebAPI.Application.ViewModels;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly IOfficeValidationService _officeValidationService;
        private readonly IMapper _mapper;

        public OfficeController(IOfficeService officeService, 
                                IOfficeValidationService officeValidationService, 
                                IMapper mapper)
        {
            _officeService = officeService;
            _officeValidationService = officeValidationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfficeViewModel>>> GetAll()
        {
            var response = await _officeService.GetAll();

            if(response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] OfficeViewModel office)
        {
            var item = _mapper.Map<OfficeDomain>(office);

            var validate = _officeValidationService.Validate(item);

            if(validate != null)
                return BadRequest(validate);

            var officeByName = await _officeService.GetByName(item.Name);

            if(officeByName != null)
                return BadRequest($"Já existe um escritório chamado {item.Name}");

            var response = await _officeService.Add(item);

            if(response)
                return Ok();

            return BadRequest();               
        }

        

             

        
    }
}