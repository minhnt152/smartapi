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
    [Route("api/facilities")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepo _repository;
        private readonly IMapper _mapper;

        public FacilityController(IFacilityRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/facilities
        [HttpGet]
        public ActionResult <IEnumerable<FacilityReadDto>> GetAllFacilitys()
        {
            var items = _repository.GetAllFacilitys();
            return Ok(_mapper.Map<IEnumerable<FacilityReadDto>>(items));
        }


        //GET api/facilities/id
        [HttpGet("{id}", Name="GetFacilityById")]
        public ActionResult<FacilityReadDto> GetFacilityById(int id)
        {
            var item = _repository.GetFacilityById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Facility!");
            }

            return Ok(_mapper.Map<FacilityReadDto>(item));
        }
        
        //POST api/facilities
        [HttpPost]
        public ActionResult<FacilityInsertDto> CreateFacility(FacilityInsertDto cDto){
          
            var cModel = _mapper.Map<Facility>(cDto);
            _repository.CreateFacility(cModel);
            _repository.SaveChanges();

            var cReadDto = _mapper.Map<FacilityReadDto>(cModel);  
            return CreatedAtRoute(nameof(GetFacilityById), new{id = cReadDto.FacId},cReadDto); 
        }

                
        // //POST api/facilities/id/holders
        // [HttpPost("{id}/holders")]
        // public ActionResult AddCard(int id, ICollection<CardHolderInsertDto> holders){

        //     foreach(CardHolderInsertDto holder in holders){
        //         _repository.AddHolder(id,_mapper.Map<CardHolder>(holder));
        //     }
        //     _repository.SaveChanges();  
        //     return Ok("Thêm holder thành công");
        // }

        // [HttpDelete("{id}/holders")] 
        // public ActionResult DelCard(int id, CardHolderInsertDto holder){

        //     _repository.DelHolder(id,_mapper.Map<CardHolder>(holder));
        //     _repository.SaveChanges();

        //     return Ok("Xóa holder thành công");
        // }
        
        //PUT api/facilities/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFacility(int id, FacilityUpdateDto uptDto)
        {
            var uptModel = _repository.GetFacilityById(id);
            if(uptModel == null)
            {
                return NotFound();
            }

            _mapper.Map(uptDto, uptModel);
            _repository.UpdateFacility(uptModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DelFacility(int id){
            var schModelFromRepo = _repository.GetFacilityById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelFacility(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    
    }
} 