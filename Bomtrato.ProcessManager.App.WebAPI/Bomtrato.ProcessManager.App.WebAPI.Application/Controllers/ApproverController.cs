using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bomtrato.ProcessManager.App.WebAPI.Application.ViewModels;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApproverController : ControllerBase
    {
        private readonly IApproverService _approverService;
        private readonly IMapper _mapper; 

        public ApproverController(IApproverService approverService, IMapper mapper)
        {
            _approverService = approverService;
            _mapper = mapper;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<ApproverViewModel>> Auth([FromBody] ApproverViewModel approverViewModel)
        {
            var item = _mapper.Map<ApproverDomain>(approverViewModel);

            var auth = await _approverService.Auth(item);

            var response = _mapper.Map<ApproverViewModel>(auth);

            if(response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<ApproverViewModel>>> GetAll()
        {
            var items = await _approverService.GetAll();

            var response = _mapper.Map<List<ApproverViewModel>>(items);

            if(response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApproverViewModel>> GetById(Guid id)
        {
            var item = await _approverService.Get(id);

            var response = _mapper.Map<ApproverViewModel>(item);

            if(response != null)
                return Ok(response);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] ApproverViewModel approver)
        {
            var item = _mapper.Map<ApproverDomain>(approver);

            var response = await _approverService.Add(item);

            if(response)
                return Ok();

            return BadRequest();               
        }

        [HttpPut]
        public async Task<ActionResult<ApproverViewModel>> Update([FromBody] ApproverViewModel approver)
        {
            var item = _mapper.Map<ApproverDomain>(approver);

            var itemAlter = await _approverService.Update(item);

            var response = _mapper.Map<ApproverViewModel>(itemAlter);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var response = await _approverService.Delete(id);

            if(response)
                return Ok();

            return BadRequest();
        }       

        

    }
}