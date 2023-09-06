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
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepo _repository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/schedules
        [HttpGet]
        public ActionResult <IEnumerable<ScheduleReadDto>> GetAllSchedule()
        {
            var items = _repository.GetAllSchedules();
            return Ok(_mapper.Map<IEnumerable<ScheduleReadDto>>(items));
        }

        //GET api/schedules/id
        [HttpGet("{id}", Name="GetScheduleById")]
        public ActionResult<ScheduleReadDto> GetScheduleById(int id)
        {
            var item = _repository.GetSchedulekById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Schedule!");
            }
            return Ok(_mapper.Map<ScheduleReadDto>(item));
        }

        //POST api/schedules
        [HttpPost]
        public ActionResult<ScheduleInsertDto> CreateSchedule(ScheduleInsertDto schDto){
            var schModel = _mapper.Map<Schedule>(schDto);
            _repository.CreateSchedule(schModel);
            _repository.SaveChanges();

            var schReadDto = _mapper.Map<ScheduleReadDto>(schModel);        
            return CreatedAtRoute(nameof(GetScheduleById), new{id = schReadDto.SchId},schReadDto);                   
        }

        //PUT api/schedules/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSchedule(int id, ScheduleUpdateDto schDto)
        {
            var schModel = _repository.GetSchedulekById(id);
            if(schModel == null)
            {
                return NotFound();
            }

            _mapper.Map(schDto, schModel);
            _repository.UpdateSchedule(schModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult Deletechedule(int id){
            var schModelFromRepo = _repository.GetSchedulekById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelSchedule(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 