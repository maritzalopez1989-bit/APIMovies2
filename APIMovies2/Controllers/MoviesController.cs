using APIMovies2.DAL.Models.Dtos;
using APIMovies2.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet(Name = "GetMoviesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);

            if (movie == null)
            {
                return NotFound(new { message = $"No se encontró la película con Id {id}." });
            }

            return Ok(movie);
        }

        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateDto movieCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdMovie = await _movieService.CreateMovieAsync(movieCreateDto);

                return CreatedAtRoute(
                    "GetMovieAsync",
                    new { id = createdMovie.Id },
                    createdMovie
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}", Name = "UpdateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(int id, [FromBody] MovieUpdateDto movieUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedMovie = await _movieService.UpdateMovieAsync(id, movieUpdateDto);

                if (updatedMovie == null)
                {
                    return NotFound(new { message = $"No se encontró la película con Id {id}." });
                }

                return Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                var deleted = await _movieService.DeleteMovieAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = $"No se encontró la película con Id {id}." });
                }

                return Ok(new { message = $"Película con Id {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}