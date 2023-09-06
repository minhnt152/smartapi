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
    [Route("api/cardholders")]
    [ApiController]
    public class CardHolderController : ControllerBase
    {
        private readonly ICardHolderRepo _repository;
        private readonly IMapper _mapper;

        public CardHolderController(ICardHolderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/cardholders
        [HttpGet]
        public ActionResult <IEnumerable<CardHolderReadDto>> GetAllHolders()
        {
            var items = _repository.GetAllCardHolders();
            return Ok(_mapper.Map<IEnumerable<CardHolderReadDto>>(items));
        }


        //GET api/cardholders/id
        [HttpGet("{id}", Name="GetCardHolderById")]
        public ActionResult<CardHolderReadDto> GetCardHolderById(int id)
        {
            var item = _repository.GetCardHolderById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Holder!");
            }

            return Ok(_mapper.Map<CardHolderReadDto>(item));
        }
        
        //POST api/cardholders
        [HttpPost]
        public ActionResult<CardHolderInsertDto> CreateCardHolder(CardHolderInsertDto cDto){
          
            var cModel = _mapper.Map<CardHolder>(cDto);
            _repository.CreateCardHolder(cModel);
            _repository.SaveChanges();

            var cReadDto = _mapper.Map<CardHolderReadDto>(cModel);  
            return CreatedAtRoute(nameof(GetCardHolderById), new{id = cReadDto.ChId},cReadDto); 
        }

                
        //POST api/cardholders/id/cards
        [HttpPost("{id}/cards")]
        public ActionResult AddCard(int id, ICollection<CardReadDto> cards){

            foreach(CardReadDto card in cards){
                _repository.AddCard(id,_mapper.Map<Card>(card));
            }
            _repository.SaveChanges();  
            return Ok("Thêm thẻ thành công");
        }

        [HttpDelete("{id}/cards")] 
        public ActionResult DelCard(int id, CardReadDto card){

            _repository.DelCard(id,_mapper.Map<Card>(card));
            _repository.SaveChanges();

            return Ok("Xóa thẻ thành công");
        }

        //POST api/cardholders/id/rights
        [HttpPost("{id}/rights")]
        public ActionResult AddRights(int id, ICollection<AccessRightBasicDto> rights){

            foreach(AccessRightBasicDto right in rights){
                _repository.AddRights(id,_mapper.Map<AccessRight>(right));
            }
            _repository.SaveChanges();  
            return Ok("Thêm quyền thành công");
        }

        [HttpDelete("{id}/rights")] 
        public ActionResult DelRight(int id, AccessRightBasicDto right){

            _repository.DelRight(id,_mapper.Map<AccessRight>(right));
            _repository.SaveChanges();

            return Ok("Xóa quyền thành công");
        }

        //POST api/cardholders/id/citizencards
        [HttpPost("{id}/citizencards")]
        public ActionResult AddIdCard(int id, CitizenIDCardInsertDto card){

            _repository.AddCitizenIdCard(id,_mapper.Map<CitizenIdCard>(card));
            _repository.SaveChanges();  
            return Ok("Thêm CCCD thành công");
        }

        [HttpDelete("{id}/citizencards")] 
        public ActionResult DelRight(int id){

            _repository.DelCitizenIdCard(id);
            _repository.SaveChanges();

            return Ok("Xóa CCCD thành công");
        }

        //PUT api/cardholders/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCardHolder(int id, CardHolderUpdateDto uptDto)
        {
            var uptModel = _repository.GetCardHolderById(id);
            if(uptModel == null)
            {
                return NotFound();
            }

            _mapper.Map(uptDto, uptModel);
            _repository.UpdateCardHolder(uptModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DelCardHolder(int id){
            var schModelFromRepo = _repository.GetCardHolderById(id);
            if(schModelFromRepo==null){
                return NotFound();
            }
            _repository.DelCardHolder(schModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    
    }
} 