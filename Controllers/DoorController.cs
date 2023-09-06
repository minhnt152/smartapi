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
    [Route("api/doors")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepo _repository;
        private readonly IMapper _mapper;

        public DoorController(IDoorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/doors
        [HttpGet]
        public ActionResult <IEnumerable<DoorReadDto>> GetAllDoors()
        {
            var items = _repository.GetAllDoors();
            return Ok(_mapper.Map<IEnumerable<DoorReadDto>>(items));
        }

        //GET api/doors/id
        [HttpGet("{id}", Name="GetDoorById")]
        public ActionResult<DoorReadDto> GetDoorById(int id)
        {
            var items = _repository.GetDoorById(id);

            return Ok(_mapper.Map<DoorReadDto>(items));
        }

        //GET api/doors/name
        [HttpGet("name/{name}")]
        public ActionResult <IEnumerable<DoorReadDto>> GetDoorByName(string name)
        {
            var items = _repository.GetDoorsByName(name);
            return Ok(_mapper.Map<IEnumerable<DoorReadDto>>(items));
        }

        //GET api/doors/ctrlr
        [HttpGet("ctrlr/{id}")]
        public ActionResult <IEnumerable<DoorReadDto>> GetDoorsByCtrlrId(int id)
        {
            var items = _repository.GetDoorsByCtrlrId(id);
            return Ok(_mapper.Map<IEnumerable<DoorReadDto>>(items));
        }



        //POST api/doors
        [HttpPost]
        public ActionResult<DoorInsertDto> CreateDoor(DoorInsertDto dDto){
            var dModel = _mapper.Map<Door>(dDto);
            _repository.CreateDoor(dModel);
            _repository.SaveChanges();

            var dReadDto = _mapper.Map<DoorReadDto>(dModel);        
            return CreatedAtRoute(nameof(GetDoorById), new{id = dReadDto.DoorId},dReadDto);                   
        }

        //PUT api/doors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDoor(int id, DoorUpdateDto dDto)
        {
            var dModel = _repository.GetDoorById(id);
            if(dModel == null)
            {
                return NotFound();
            }

            _mapper.Map(dDto, dModel);
            _repository.UpdateDoor(dModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteDoor(int id){
            var dModelFromRepo = _repository.GetDoorById(id);
            if(dModelFromRepo==null){
                return NotFound();
            }
            _repository.DelDoor(dModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 