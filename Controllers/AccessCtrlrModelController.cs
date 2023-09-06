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
    [Route("api/ctrlrmodels")]
    [ApiController]
    public class AccessCtrlrModelController : ControllerBase
    {
        private readonly IAccessCtrlrModelRepo _repository;
        private readonly IMapper _mapper;

        public AccessCtrlrModelController(IAccessCtrlrModelRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/ctrlrmodels
        [HttpGet]
        public ActionResult <IEnumerable<AccessCtrlrModelReadDto>> GetAllModels()
        {
            var items = _repository.GetAllCtrlrModels();
            return Ok(_mapper.Map<IEnumerable<AccessCtrlrModelReadDto>>(items));
        }

        //GET api/ctrlrmodels/id
        [HttpGet("{id}", Name="GetModelById")]
        public ActionResult<AccessCtrlrModelReadDto> GetModelById(int id)
        {
            var items = _repository.GetCtrlrModelById(id);

            return Ok(_mapper.Map<AccessCtrlrModelReadDto>(items));
        }
    }
} 