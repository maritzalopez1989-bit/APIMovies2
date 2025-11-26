using APIMovies2.DAL.Models;
using APIMovies2.DAL.Models.Dtos;
using APIMovies2.Repository.IRepository;
using APIMovies2.Services.IServices;
using AutoMapper;

namespace APIMovies2.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new InvalidOperationException("Ocurrió un error al crear la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var exists = await _movieRepository.MovieExistsByIdAsync(id);

            if (!exists)
            {
                return false;
            }

            return await _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto)
        {
            var existingMovie = await _movieRepository.GetMovieAsync(id);

            if (existingMovie == null)
            {
                return null;
            }

            // Mapear los cambios al modelo existente
            var movie = _mapper.Map<Movie>(movieUpdateDto);
            movie.Id = id;
            movie.CreatedDate = existingMovie.CreatedDate;

            var updated = await _movieRepository.UpdateMovieAsync(movie);

            if (!updated)
            {
                throw new InvalidOperationException("Ocurrió un error al actualizar la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }
    }
}