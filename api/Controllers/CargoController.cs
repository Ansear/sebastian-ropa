using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
public class CargoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CargoController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
    {
        var cargo = await _unitOfWork.Cargos.GetAllAsync();
        return _mapper.Map<List<CargoDto>>(cargo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoDto>> Get(int id)
    {
        var cargo = await _unitOfWork.Cargos.GetAllAsync();
        if( cargo == null)
            return  NotFound();
        
        return _mapper.Map<CargoDto>(cargo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cargo>> Post([FromBody] CargoDto cargoDto)
    {
        var cargo = _mapper.Map<Cargo>(cargoDto);
        _unitOfWork.Cargos.Add(cargo);
        await _unitOfWork.SaveAsync();
        if( cargo == null)
            return  BadRequest();
        cargoDto.Id = cargo.Id;        
        return CreatedAtAction(nameof(Post), new{Id = cargoDto.Id}, cargoDto);
    }

    [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto cargoDto)
    {
        if(cargoDto == null)
            return BadRequest();
        if(cargoDto.Id == 0)
            cargoDto.Id = id;
        if(cargoDto.Id != id)
            return NotFound();
        var cargo = _mapper.Map<Cargo>(cargoDto);
        _unitOfWork.Cargos.Update(cargo);
        await _unitOfWork.SaveAsync();
        return cargoDto;
    }

    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cargo = await _unitOfWork.Cargos.GetByIdAsync(id);
        if(cargo == null)
            return NotFound();
        _unitOfWork.Cargos.Remove(cargo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
