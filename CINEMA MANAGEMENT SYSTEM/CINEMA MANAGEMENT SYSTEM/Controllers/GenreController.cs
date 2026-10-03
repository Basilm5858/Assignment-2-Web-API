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
    public class GenreController : ControllerBase
    {
        private readonly IGenre _genreRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenreController(IGenre genreRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genreRepo = genreRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("EndPoint1")]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreRepo.GetAll();
            if(genres == null)
            {
                return NotFound("No genres found.");
            }
            return Ok(genres);
        }

        [HttpGet("EndPoint2")]
        public async Task<IActionResult> GetById(int id)
        {
            var genres = await _genreRepo.GetById(id);

            if (genres == null)
            {
                return NotFound("No genres found.");
            }
            return Ok(genres);
        }

        [HttpGet("EndPoint3")]
        public async Task<IActionResult> Create(CreateGenreDTO dto)
        {
            var genre = _mapper.Map<Genre>(dto);
            await _genreRepo.Add(genre);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
        }

        [HttpGet("EndPoint4")]
        public async Task<IActionResult> Update(int id, UpdateGenreDTO dto)
        {
            var genre = await _genreRepo.GetById(id);
            if (genre == null)
            {
                return NotFound("Genre not found.");
            }

            _mapper.Map(dto, genre);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("EndPoint5")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepo.GetById(id);
            if (genre == null)
            {
                return NotFound("Genre not found.");
            }

            _genreRepo.Delete(genre);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("EndPoint6")]
        public async Task<IActionResult> EndPoint6()
        {
            var genres = await _genreRepo.EndPoint6();
            if (genres == null)
            {
                return NotFound("Genre not found.");
            }

            return Ok(genres);
        }
    }
}
