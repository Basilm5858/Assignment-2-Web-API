using AutoMapper;
using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;
using CINEMA_MANAGEMENT_SYSTEM.Repo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CINEMA_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movie;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MovieController(IMovie movie, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _movie = movie;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("EndPoint1")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movie.GetAll();
            if (movies == null)
            {
                return NotFound("No movies found.");
            }
            var res = _mapper.Map<ICollection<MovieDTOEndPoint1>>(movies);
            return Ok(res);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetByIdMovie(int id)
        {
            var movies = await _movie.GetById(id);

            if (movies == null)
            {
                return NotFound("No movies found.");
            }

            var res = _mapper.Map<MovieDTOEndPoint1>(movies);
            return Ok(res);
        }

        [HttpPost("EndPoint3")]
        public async Task<IActionResult> CreateMovie(CreateMovieDTOEndPoint3 dto)
        {
            var movie = _mapper.Map<Movie>(dto);

            await _movie.Add(movie);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("EndPoint4")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDTOEndPoint4 dto)
        {
            var movie = await _movie.GetById(id);

            var res = _mapper.Map(movie, dto);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("EndPoint5")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movie.GetById(id);

            if(movie == null)
            {
                return NotFound("movie is not found");
            }

            _movie.Delete(movie);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("EndPoint6")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            var movies = await _movie.EndPoint6(title);

            if (movies == null)
            {
                return NotFound("No movies found.");
            }

            var res = _mapper.Map<ICollection<MovieDTOEndPoint6>>(movies);
            return Ok(res);
        }

    }
}
