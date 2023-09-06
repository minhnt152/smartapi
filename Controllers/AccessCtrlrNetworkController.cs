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
    [Route("api/ctrlrnetworks")]
    [ApiController]
    public class AccessCtrlrNetworkController : ControllerBase
    {
        private readonly IAccessCtrlrNetworkRepo _repository;
        private readonly IMapper _mapper;

        public AccessCtrlrNetworkController(IAccessCtrlrNetworkRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/ctrlrnetworks
        [HttpGet]
        public ActionResult <IEnumerable<AccessCtrlrNetworkReadDto>> GetAllCtrlrNetworks()
        {
            var items = _repository.GetAllCtrlrNetworks();
            return Ok(_mapper.Map<IEnumerable<AccessCtrlrNetworkReadDto>>(items));
        }

        //GET api/ctrlrnetworks/id
        [HttpGet("{id}", Name="GetCtrlrNetworkById")]
        public ActionResult<AccessCtrlrNetworkReadDto> GetCtrlrNetworkById(int id)
        {
            var item = _repository.GetCtrlrNetworkById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy Network!");
            }
            return Ok(_mapper.Map<AccessCtrlrNetworkReadDto>(item));
        }

        //POST api/ctrlrnetworks
        [HttpPost]
        public ActionResult<AccessCtrlrNetworkInsertDto> CreateNetwork(AccessCtrlrNetworkInsertDto netDto){
            var netModel = _mapper.Map<AccessControllerNetwork>(netDto);
            _repository.CreateNetwork(netModel);
            _repository.SaveChanges();

            var netReadDto = _mapper.Map<AccessCtrlrNetworkReadDto>(netModel);        
            return CreatedAtRoute(nameof(GetCtrlrNetworkById), new{id = netReadDto.NetworkId},netReadDto);                   
        }

        //PUT api/ctrlrnetworks/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateNetwork(int id, AccessCtrlrNetworkUpdateDto netDto)
        {
            var netModel = _repository.GetCtrlrNetworkById(id);
            if(netModel == null)
            {
                return NotFound();
            }

            _mapper.Map(netDto, netModel);
            _repository.UpdateNetwork(netModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")] 
        public ActionResult DeleteNetwork(int id){
            var netModelFromRepo = _repository.GetCtrlrNetworkById(id);
            if(netModelFromRepo==null){
                return NotFound();
            }
            _repository.DelNetwork(netModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
} 