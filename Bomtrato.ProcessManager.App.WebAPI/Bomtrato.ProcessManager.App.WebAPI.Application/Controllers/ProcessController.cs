using System;
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
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;
        private readonly IProcessValidationService _processValidationService;
        private readonly IMapper _mapper;

        public ProcessController(IProcessService processService, 
                                 IProcessValidationService processValidationService, 
                                 IMapper mapper)
        {
            _processService = processService;
            _processValidationService = processValidationService;
            _mapper = mapper;            
        }

        [HttpGet]
        public async Task<ActionResult<List<ProcessViewModel>>> GetAll()
        {
            var items = await _processService.GetAll();

            var response = _mapper.Map<List<ProcessViewModel>>(items);

            if(response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessViewModel>> GetById(Guid id)
        {
            var item = await _processService.Get(id);

            var response = _mapper.Map<ProcessViewModel>(item);

            if(response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{filter}/{active:int}/{approved:int}")]
        public async Task<ActionResult<List<ProcessViewModel>>> Filter(string filter, int active, int approved)
        {
            var items = await _processService.Filter(filter, active, approved);

            var response = _mapper.Map<List<ProcessViewModel>>(items);

            if (response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<List<string>>> Add([FromBody] ProcessViewModel process)
        {
            var item = _mapper.Map<ProcessDomain>(process);

            var validate = _processValidationService.Validate(item);

            if(validate != null)
                return BadRequest(validate);

            var processByNumber = await _processService.Get(item.Number);

            if(processByNumber != null)
                return BadRequest($"Ops já existe um processo cadastrado com o número {item.Number}!");

            var response = await _processService.Add(item);

            if(response)
                return Ok();

            return BadRequest();               
        }

        [HttpPut]
        public async Task<ActionResult<ProcessViewModel>> Update([FromBody] ProcessViewModel process)
        {
            var item = _mapper.Map<ProcessDomain>(process);

            var itemAlter = await _processService.Update(item);

            var response = _mapper.Map<ProcessViewModel>(itemAlter);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var response = await _processService.Delete(id);

            if(response)
                return Ok();

            return BadRequest();
        }       

        

        
    }
}