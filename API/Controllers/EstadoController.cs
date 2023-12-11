using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EstadoDto>> GetEstados()
        {
            var result = await _unitOfWork.Estados.GetAllAsync();
            return _mapper.Map<IEnumerable<EstadoDto>>(result);
        }
        [HttpGet("{id}")]
        public async Task<EstadoDto> GetEstadosById(int id)
        {
            var result = await _unitOfWork.Estados.GetByIdAsync(id);
            return _mapper.Map<EstadoDto>(result);
        }
        [HttpPost] // 2611
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoDto>> Post(EstadoDto resultDto)
        {
            var result = _mapper.Map<Estado>(resultDto);
            _unitOfWork.Estados.Add(result);
            await _unitOfWork.SaveAsync();
            if (result == null)
            {
                return BadRequest();
            }
            resultDto.Id = result.Id;
            return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
        }
        [HttpPut("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto resultDto)
        {
            var exists = await _unitOfWork.Estados.GetByIdAsync(id);
            if (exists == null)
            {
                return NotFound();
            }
            if (resultDto.Id == 0)
            {
                resultDto.Id = id;
            }
            if (resultDto.Id != id)
            {
                return BadRequest();
            }
            // Update the properties of the existing entity with values from resultDto
            // The context is already tracking result, so no need to attach it
            _mapper.Map(resultDto, exists);
            await _unitOfWork.SaveAsync();
            // Return the updated entity
            return _mapper.Map<EstadoDto>(exists);
        }
        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Estados.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Estados.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}