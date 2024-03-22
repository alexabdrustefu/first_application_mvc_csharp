using System;
using System.Collections.Generic;
using AutoMapper;
using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Models;
using first_mvc_pattern_c_.Services;
using Microsoft.AspNetCore.Mvc;

namespace first_mvc_pattern_c_.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly CinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemasController(CinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService ?? throw new ArgumentNullException(nameof(cinemaService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/cinema
        [HttpGet]
        public ActionResult<IEnumerable<CinemaDto>> GetCinemas()
        {
            var cinemas = _cinemaService.GetAllCinemas();
            var cinemaDtos = _mapper.Map<IEnumerable<CinemaDto>>(cinemas);
            return Ok(cinemaDtos);
        }

        // GET: api/cinema/5
        [HttpGet("{id}")]
        public ActionResult<CinemaDto> GetCinema(int id)
        {
            var cinema = _cinemaService.GetCinemaById(id);
            if (cinema == null)
            {
                return NotFound();
            }
            var cinemaDto = _mapper.Map<CinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        // POST: api/cinema
        [HttpPost]
        public ActionResult<CinemaDto> PostCinema(CinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaService.AddCinema(cinema);
            var createdCinemaDto = _mapper.Map<CinemaDto>(cinema);
            return CreatedAtAction(nameof(GetCinema), new { id = createdCinemaDto.CinemaId }, createdCinemaDto);
        }

        // PUT: api/cinema/5
        [HttpPut("{id}")]
        public IActionResult PutCinema(int id, CinemaDto cinemaDto)
        {
            if (id != cinemaDto.CinemaId)
            {
                return BadRequest();
            }
            var cinemaToUpdate = _mapper.Map<Cinema>(cinemaDto);
            _cinemaService.UpdateCinema(id,cinemaToUpdate);
            return NoContent();
        }

        // DELETE: api/cinema/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            _cinemaService.DeleteCinema(id);
            return NoContent();
        }
    }
}
