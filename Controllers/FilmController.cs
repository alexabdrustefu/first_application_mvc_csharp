using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using first_mvc_pattern_c_.Services;
using Microsoft.AspNetCore.Mvc;

namespace first_mvc_pattern_c_.Controllers
{
    [Route("api/film")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly FilmService _filmService;
        private readonly IMapper _mapper;

        public FilmController(FilmService filmService, IMapper mapper)
        {
            _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/film
        [HttpGet]
        public ActionResult<IEnumerable<FilmDTO>> GetFilms()
        {
            var films = _filmService.GetAllFilms();
            var filmDtos = _mapper.Map<IEnumerable<FilmDTO>>(films);
            return Ok(filmDtos);
        }

        // GET: api/film/5
        [HttpGet("{id}")]
        public ActionResult<FilmDTO> GetFilm(int id)
        {
            var film = _filmService.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }
            var filmDto = _mapper.Map<FilmDTO>(film);
            return Ok(filmDto);
        }

        // POST: api/film
        [HttpPost]
        public ActionResult<FilmDTO> PostFilm(FilmDTO filmDto)
        {
            var film = _mapper.Map<Film>(filmDto);
            _filmService.AddFilm(film);
            var createdFilmDto = _mapper.Map<FilmDTO>(film);
            return CreatedAtAction(nameof(GetFilm), new { id = createdFilmDto.FilmId }, createdFilmDto);
        }

        // PUT: api/film/5
        [HttpPut("{id}")]
        public IActionResult PutFilm(int id, FilmDTO filmDto)
        {
            if (id != filmDto.FilmId)
            {
                return BadRequest();
            }
            var filmToUpdate = _mapper.Map<Film>(filmDto);
            _filmService.UpdateFilm(id, filmToUpdate);
            return NoContent();
        }

        // DELETE: api/film/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            _filmService.DeleteFilm(id);
            return NoContent();
        }
    }
}
