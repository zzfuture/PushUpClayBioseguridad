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
    public class EmpleadoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EmpleadoDto>> GetEmpleados()
        {
            var result = await _unitOfWork.Empleados.GetAllAsync();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(result);
        }
        [HttpGet("Vigilantes")]
        public async Task<IEnumerable<EmpleadoDto>> GetEmpleadosVigilantes()
        {
            var result = await _unitOfWork.Empleados.GetVigilantes();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(result);
        }
        [HttpGet("TelefonoVigilante")]
        public async Task<IEnumerable<object>> GetTelefonoVigilantes()
        {
            var result = await _unitOfWork.Empleados.GetVigilanteNumero();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<EmpleadoDto> GetEmpleadosById(int id)
        {
            var result = await _unitOfWork.Empleados.GetByIdAsync(id);
            return _mapper.Map<EmpleadoDto>(result);
        }
        [HttpGet("EmpleadoPiedecuestaYGiron")]
        public async Task<IEnumerable<EmpleadoDto>> GetEmpleadoPiedecuestaYGiron()
        {
            var result = await _unitOfWork.Empleados.GetEmpleadoGironYPiedecueseta();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(result);
        }
        [HttpPost] // 2611
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto resultDto)
        {
            var result = _mapper.Map<Empleado>(resultDto);
            _unitOfWork.Empleados.Add(result);
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
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto resultDto)
        {
            var exists = await _unitOfWork.Empleados.GetByIdAsync(id);
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
            return _mapper.Map<EmpleadoDto>(exists);
        }
        [HttpDelete("{id}")] // 2611
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Empleados.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            _unitOfWork.Empleados.Remove(result);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}