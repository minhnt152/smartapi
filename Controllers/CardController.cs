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
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepo _repository;
        private readonly IMapper _mapper;

        public CardController(ICardRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/cards
        [HttpGet]
        public ActionResult <IEnumerable<CardReadDto>> GetAllCards()
        {
            var items = _repository.GetAllCards();
            return Ok(_mapper.Map<IEnumerable<CardReadDto>>(items));
        }


        //GET api/cards/id
        [HttpGet("{id}", Name="GetCardById")]
        public ActionResult<CardReadDto> GetCardById(int id)
        {
            var item = _repository.GetCardById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Card!");
            }
            return Ok(_mapper.Map<CardReadDto>(item));
        }

        //GET api/cards/printid/print_card_id
        [HttpGet("printid/{print_card_id}")]
        public ActionResult<CardReadDto> GetCardByPrintId(string print_card_id)
        {
            var item = _repository.GetCardByPrintId(print_card_id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Card!");
            }
            return Ok(_mapper.Map<CardReadDto>(item));
        }

        //POST api/cards
        [HttpPost]
        public ActionResult<CardInsertDto> CreateCard(CardInsertDto cDto){
            var cModel = _mapper.Map<Card>(cDto);
            _repository.CreateCard(cModel);
            _repository.SaveChanges();

            var cReadDto = _mapper.Map<CardReadDto>(cModel);        
            return CreatedAtRoute(nameof(GetCardById), new{id = cReadDto.CardId},cReadDto);                   
        }

        //PUT api/cards/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCard(int id, CardUpdateDto cDto)
        {
            var cModel = _repository.GetCardById(id);
            if(cModel == null)
            {
                return NotFound();
            }

            _mapper.Map(cDto, cModel);
            _repository.UpdateCard(cModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteCard(int id){
            var cModelFromRepo = _repository.GetCardById(id);
            if(cModelFromRepo==null){
                return NotFound();
            }
            _repository.DelCard(cModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 