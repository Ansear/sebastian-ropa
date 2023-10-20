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
public class ColorController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ColorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var result = await _unitOfWork.Colores.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var result = await _unitOfWork.Colores.GetAllAsync();
        if (result == null)
            return NotFound();

        return _mapper.Map<PaisDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Color>> Post([FromBody] PaisDto colorDto)
    {
        var result = _mapper.Map<Color>(colorDto);
        _unitOfWork.Colores.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        colorDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = colorDto.Id }, colorDto);
    }

    [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto colorDto)
    {
        if (colorDto == null)
            return BadRequest();
        if (colorDto.Id == 0)
            colorDto.Id = id;
        if (colorDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Color>(colorDto);
        _unitOfWork.Colores.Update(result);
        await _unitOfWork.SaveAsync();
        return colorDto;
    }

    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Colores.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Colores.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}