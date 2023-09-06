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
    [Route("api/accessevents")]
    [ApiController]
    public class AccessEventController : ControllerBase
    {
        private readonly IAccessEventRepo _repository;
        private readonly IMapper _mapper;

        public AccessEventController(IAccessEventRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/accessevents?startDate=......
        [HttpGet]
        public ActionResult <AccessEventItemDto> GetAccessEvents([FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate,
                                                                        [FromQuery]string? cardNo, [FromQuery]string? chName, [FromQuery]string? doorName, 
                                                                        [FromQuery]int? eventStt, [FromQuery]int? orient, [FromQuery]int pos)
        {
            int lastPost = pos;
            bool hasMore = false;
            var items = _repository.GetAccessEvents(startDate, endDate,cardNo, chName, doorName, eventStt, orient, pos, out lastPost, out hasMore);
            AccessEventItemDto itemReturn = new AccessEventItemDto();
            itemReturn.position = lastPost;
            itemReturn.hasMore = hasMore;
            itemReturn.Events = _mapper.Map<IEnumerable<AccessEventReadDto>>(items).ToList();

            return Ok(itemReturn);
        }

        //GET api/accessevents/id
        [HttpGet("{id}", Name="GetEventById")]
        public ActionResult<AccessEventReadDto> GetEventById(int id)
        {
            var items = _repository.GetAccessEventById(id);

            return Ok(_mapper.Map<AccessEventReadDto>(items));
        }

 
        //POST api/accessevents
        [HttpPost]
        public ActionResult<AccessEventInsertDto> CreateEvent(AccessEventInsertDto evtDto){
            var evtModel = _mapper.Map<AccessEvent>(evtDto);
            _repository.CreateAccessEvent(evtModel);
            _repository.SaveChanges();

            var evtReadDto = _mapper.Map<AccessEventReadDto>(evtModel);        
            return CreatedAtRoute(nameof(GetEventById), new{id = evtReadDto.EventId},evtReadDto);                   
        }
    }
} 