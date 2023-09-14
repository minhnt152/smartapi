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
    [Route("api/tableupdates")]
    [ApiController]
    public class TableUpdateController : ControllerBase
    {
        private readonly ITableUpdateRepo _repository;
        private readonly IMapper _mapper;

        public TableUpdateController(ITableUpdateRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/tableupdates
        [HttpGet]
        public ActionResult <IEnumerable<TableUpdateReadDto>> GetAllTableUpdate()
        {
            var items = _repository.GetAllTableUpdate();
            return Ok(_mapper.Map<IEnumerable<TableUpdateReadDto>>(items));
        }

        //GET api/tableupdates/id
        [HttpGet("{id}", Name="GetTableUpdateById")]
        public ActionResult<TableUpdateReadDto> GetTableUpdateById(int id)
        {
            var item = _repository.GetTableUpdateById(id);
            if(item==null)
            {
                return NotFound("Không tìm thấy thông tin!");
            }
            return Ok(_mapper.Map<TableUpdateReadDto>(item));
        }
        
    }
} 