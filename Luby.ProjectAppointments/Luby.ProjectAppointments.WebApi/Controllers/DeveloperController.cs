using Luby.ProjectAppointments.Application.Interfaces;
using Luby.ProjectAppointments.Application.ViewModel.Developer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.WebApi.Controllers
{
    [Route("Api/v1/[controller]")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperAppService _developerAppService;

        public DeveloperController(IDeveloperAppService developerAppService)
        {
            _developerAppService = developerAppService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _developerAppService.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _developerAppService.GetById(id);
                if (result == null || result?.Id == Guid.Empty)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] NewDeveloperViewModel newDeveloperViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _developerAppService.Create(newDeveloperViewModel);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _developerAppService.Remove(id);
                return Ok();

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] DeveloperViewModel developerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _developerAppService.Update(developerViewModel);
                var result = await _developerAppService.GetById(developerViewModel.Id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    
    }
}
