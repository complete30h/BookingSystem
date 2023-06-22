using BookingSystem.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Presentation
{
    [Route("api/voice-types")]
    [ApiController]
    public class VoiceTypeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public VoiceTypeController(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetAllVoiceTypes")]
        public async Task<IActionResult> GetAllVoiceTypes()
        {
            var voiceTypes = await _service.VoiceTypeService.GetAllVoiceTypesAsync(trackChanges: false);
            return Ok(voiceTypes);
        }

        [HttpGet("{id:int}", Name = "GetVoiceTypeById")]
        public async Task<IActionResult> GetVoiceType(int id)
        {
            var voiceType = await _service.VoiceTypeService.GetVoiceTypeAsync(id, trackChanges: false);
            return Ok(voiceType);
        }

        [HttpPost(Name = "CreateVoiceType")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVoiceType([FromBody] VoiceTypeDto voiceType)
        {
            var createdVoiceType = await _service.VoiceTypeService.CreateVoiceType(voiceType);

            return CreatedAtRoute("GetVoiceTypeById", new { id = createdVoiceType.Id }, createdVoiceType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _service.VoiceTypeService.DeleteVoiceType(id, trackChanges: false);
            return NoContent();
        }
    }
}
