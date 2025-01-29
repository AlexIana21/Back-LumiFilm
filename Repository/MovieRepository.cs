using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class MovieRepository : IMovieRepository
    { 
        private readonly string _connectionString;

        public MovieRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var movies = new List<Movie>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var movie = new Movie
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Synopsis = reader.GetString(2),
                                Duration = reader.GetInt32(3),
                                Rating = reader.GetInt32(4),
                                Genre = reader.GetString(5),
                                Director = reader.GetString(6),
                                Poster = reader.GetString(7)
                            }; 

                            movies.Add(movie);
                        }
                    }
                }
            }
            return movies;
        }

        public async Task AddAsync(Movie movie)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Synopsis", movie.Synopsis);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Rating", movie.Rating);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Director", movie.Director);
                    command.Parameters.AddWithValue("@Poster", movie.Poster);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
               await connection.OpenAsync();

               string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
               
            }
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            Movie movie = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            movie = new Movie
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Synopsis = reader.GetString(2),
                                Duration = reader.GetInt32(3),
                                Rating = reader.GetInt32(4),
                                Genre = reader.GetString(5),
                                Director = reader.GetString(6),
                                Poster = reader.GetString(7)
                            }; 
                        }
                    }
                }
            }
            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Synopsis", movie.Synopsis);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Rating", movie.Rating);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Director", movie.Director);
                    command.Parameters.AddWithValue("@Poster", movie.Poster);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}