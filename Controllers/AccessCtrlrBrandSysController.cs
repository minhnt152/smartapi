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
    [Route("api/ctrlrbrandsys")]
    [ApiController]
    public class AccessCtrlrBrandSysController : ControllerBase
    {
        private readonly IAccessCtrlrBrandSysRepo _repository;
        private readonly IMapper _mapper;

        public AccessCtrlrBrandSysController(IAccessCtrlrBrandSysRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/ctrlrbrandsys
        [HttpGet]
        public ActionResult <IEnumerable<AccessCtrlrBrandSysReadDto>> GetAllBrandSys()
        {
            var items = _repository.GetAllCtrlrBrandSystems();
            return Ok(_mapper.Map<IEnumerable<AccessCtrlrBrandSysReadDto>>(items));
        }

        //GET api/ctrlrbrandsys/id
        [HttpGet("{id}", Name="GetBrandSys")]
        public ActionResult<AccessCtrlrBrandSysReadDto> GetBrandSys(int id)
        {
            var items = _repository.GetCtrlrBrandSystemById(id);

            return Ok(_mapper.Map<AccessCtrlrBrandSysReadDto>(items));
        }
    }
} 