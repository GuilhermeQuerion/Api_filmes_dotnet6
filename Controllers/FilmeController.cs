using AutoMapper;
using Curso_Api6.Data;
using Curso_Api6.Dtos;
using Curso_Api6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Curso_Api6.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) {
            //Mapeia de um FilmeDto para CreateFilmeDto
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            //Salva as Alterações
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.ID }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes() {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id) {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
            if (filme != null) {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            } else {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutFilme(int id, [FromBody] UpdateFilmeDto filmeDto) {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
            if (filme != null) {
                _mapper.Map(filmeDto, filme);
                _context.SaveChanges();
                return NoContent();
            } else {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id) {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.ID == id);
            if (filme != null) {
                _context.Remove(filme);
                _context.SaveChanges();
                return NoContent();
            } else {
                return NotFound();
            }
        }
    }
}
