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
    [Route("api/controllers")]
    [ApiController]
    public class AccessCtrlrController : ControllerBase
    {
        private readonly IAccessCtrlrRepo _repository;
        private readonly IMapper _mapper;

        public AccessCtrlrController(IAccessCtrlrRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/controllers
        [HttpGet]
        public ActionResult <IEnumerable<AccessCtrlrReadDto>> GetAllCtrlr()
        {
            var items = _repository.GetAllCtrlr();
            return Ok(_mapper.Map<IEnumerable<AccessCtrlrReadDto>>(items));
        }


        //GET api/controllers/id
        [HttpGet("{id}", Name="GetCtrlrById")]
        public ActionResult<AccessCtrlrReadDto> GetCtrlrById(int id)
        {
            var item = _repository.GetCtrlrById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Controllers!");
            }

            return Ok(_mapper.Map<AccessCtrlrReadDto>(item));
        }
        
        //POST api/controllers
        [HttpPost]
        public ActionResult<AccessCtrlrInsertDto> CreateCtrlr(AccessCtrlrInsertDto cDto){
          
            var cModel = _mapper.Map<AccessController>(cDto);
            _repository.CreateCtrlr(cModel);
            _repository.SaveChanges();

            var cReadDto = _mapper.Map<AccessCtrlrReadDto>(cModel);  
            return CreatedAtRoute(nameof(GetCtrlrById), new{id = cReadDto.CtrlrId},cReadDto); 
        }

                
        //POST api/controllers/id/doors
        [HttpPost("{id}/doors")]
        public ActionResult AddDoors(int id, ICollection<DoorReadDto> doors){

            foreach(DoorReadDto door in doors){
                _repository.AddDoor(id,_mapper.Map<Door>(door));
            }
            _repository.SaveChanges();  
            return Ok("Thêm cửa thành công");
        }

        [HttpDelete("{id}/doors")] 
        public ActionResult DelCard(int id, DoorReadDto door){

            _repository.DelDoor(id,_mapper.Map<Door>(door));
            _repository.SaveChanges();

            return Ok("Xóa cửa thành công");
        }

               
        //PUT api/controllers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCtrlr(int id, AccessCtrlrUpdateDto uptDto)
        {
            var uptModel = _repository.GetCtrlrById(id);
            if(uptModel == null)
            {
                return NotFound();
            }

            _mapper.Map(uptDto, uptModel);
            _repository.UpdateCtrlr(uptModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DelCtrlr(int id){
            var schModelFromRepo = _repository.GetCtrlrById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelCtrlr(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    
    }
} 