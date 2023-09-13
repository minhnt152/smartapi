using System;
using System.Collections.Generic;
using System.Globalization;
using smartapi.Data;
using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace smartapi.Controllers
{
    [Route("api/settings")]
    [ApiController]
    public class AccessSettingsController : ControllerBase
    {
        private readonly ISettingRepo _repository;
        private readonly IMapper _mapper;

        public AccessSettingsController(ISettingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/settings
        [HttpGet]
        public ActionResult <IEnumerable<SettingReadDto>> GetAllSettings()
        {
            var items = _repository.GetAllSettings();
            return Ok(_mapper.Map<IEnumerable<SettingReadDto>>(items));
        }

        //GET api/settings/id
        [HttpGet("{id}", Name="GetSettingById")]
        public ActionResult<SettingReadDto> GetSettingById(int id)
        {
            var item = _repository.GetSettingById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy setting!");
            }
            return Ok(_mapper.Map<SettingReadDto>(item));
        }

        //POST api/settings
        [HttpPost]
        public ActionResult<SettingInsertDto> CreateSetting(SettingInsertDto schDto){
            var schModel = _mapper.Map<AccessSetting>(schDto);
            _repository.CreateSetting(schModel);
            _repository.SaveChanges();

            var schReadDto = _mapper.Map<SettingReadDto>(schModel);        
            return CreatedAtRoute(nameof(GetSettingById), new{id = schReadDto.SettingId},schReadDto);                   
        }

        //PUT api/settings/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSetting(int id, SettingUpdateDto schDto)
        {
            var schModel = _repository.GetSettingById(id);
            if(schModel == null)
            {
                return NotFound();
            }

            _mapper.Map(schDto, schModel);
            _repository.UpdateSetting(schModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteSetting(int id){
            var schModelFromRepo = _repository.GetSettingById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelSetting(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 