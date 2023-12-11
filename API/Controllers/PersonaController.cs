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
    public class PersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PersonaDto>> GetPersonas()
        {
            var result = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(result);
        }
        [HttpGet("{id}")]
        public async Task<PersonaDto> GetPersonasById(int id)
        {
            var result = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(result);
        }
        [HttpPost] // 2611
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto resultDto)
        {
            var result = _mapper.Map<Persona>(resultDto);
            _unitOfWork.Personas.Add(result);
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
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto resultDto)
        {
            var exists = await _unitOfWork.Personas.GetByIdAsync(id);
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
            return _mapper.Map<PersonaDto>(exists);
        }
        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Personas.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Personas.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}