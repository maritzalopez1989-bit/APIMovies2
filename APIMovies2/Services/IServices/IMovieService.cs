using APIMovies2.DAL.Models.Dtos;

namespace APIMovies2.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto);
        Task<MovieDto> UpdateMovieAsync(int id, MovieUpdateDto movieUpdateDto);
        Task<bool> DeleteMovieAsync(int id);
    }
}