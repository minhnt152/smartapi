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
    [Route("api/accessrights")]
    [ApiController]
    public class AccessRightController : ControllerBase
    {
        private readonly IAccessRightRepo _repository;
        private readonly IMapper _mapper;

        public AccessRightController(IAccessRightRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/accessrights
        [HttpGet]
        public ActionResult <IEnumerable<AccessRightReadDto>> GetAllAccessright()
        {
            var items = _repository.GetAllAccessRights();
            return Ok(_mapper.Map<IEnumerable<AccessRightReadDto>>(items));
        }


        //GET api/accessrights/id
        [HttpGet("{id}", Name="GetRightById")]
        public ActionResult<AccessRightReadDto> GetRightById(int id)
        {
            var item = _repository.GetAccessRightById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Right!");
            }

            return Ok(_mapper.Map<AccessRightReadDto>(item));
        }
        
        //POST api/accessrights
        [HttpPost]
        public ActionResult<AccessRightInsertDto> CreateAccessright(AccessRightInsertDto cDto){
          
            var cModel = _mapper.Map<AccessRight>(cDto);
            _repository.CreateAccessRight(cModel);
            _repository.SaveChanges();

            var cReadDto = _mapper.Map<AccessRightReadDto>(cModel);  
            return CreatedAtRoute(nameof(GetRightById), new{id = cReadDto.RightId},cReadDto); 
        }

                
        //POST api/accessrights/id/doors
        [HttpPost("{id}/doors")]
        public ActionResult AddDoors(int id, List<int> doorIds){

            foreach(int doorId in doorIds){
                _repository.AddDoorToRight(id,doorId);
            }
            _repository.SaveChanges();  
            return Ok("Thêm cửa thành công");
        }

        //PUT api/accessrights/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAccessRight(int id, AccessRightUpdateDto uptDto)
        {
            var uptModel = _repository.GetAccessRightById(id);
            if(uptModel == null)
            {
                return NotFound();
            }

            _mapper.Map(uptDto, uptModel);
            _repository.UpdateAccessRight(uptModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteAccessRight(int id){
            var schModelFromRepo = _repository.GetAccessRightById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelAccessRight(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}/doors")] 
        public ActionResult DelDoorInRight(int id, List<int> doorIds){
            var schModelFromRepo = _repository.GetAccessRightById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }

            foreach(int doorId in doorIds){
                _repository.DelDoorInRight(id,doorId);
            }
            _repository.SaveChanges();

            return Ok("Xóa cửa thành công");
        }
       
    }
} 