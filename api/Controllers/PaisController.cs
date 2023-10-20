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
public class PaisController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var result = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var result = await _unitOfWork.Paises.GetAllAsync();
        if (result == null)
            return NotFound();

        return _mapper.Map<PaisDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post([FromBody] PaisDto paisDto)
    {
        var result = _mapper.Map<Pais>(paisDto);
        _unitOfWork.Paises.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        paisDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = paisDto.Id }, paisDto);
    }

    [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto paisDto)
    {
        if (paisDto == null)
            return BadRequest();
        if (paisDto.Id == 0)
            paisDto.Id = id;
        if (paisDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Pais>(paisDto);
        _unitOfWork.Paises.Update(result);
        await _unitOfWork.SaveAsync();
        return paisDto;
    }

    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Paises.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Paises.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}