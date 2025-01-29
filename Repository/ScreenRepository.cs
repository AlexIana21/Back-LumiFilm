using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class ScreenRepository : IScreenRepository
{
    private readonly string _connectionString;

    public ScreenRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

        public async Task<List<Screen>> GetAllAsync()
        {
            var screens = new List<Screen>();
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
                            var screen = new Screen
                            {
                                Id = reader.GetInt32(0),
                                Capacity = reader.GetInt32(1),
                                
                            }; 

                            screens.Add(screen);
                        }
                    }
                }
            }
            return screens;
        }

        public async Task AddAsync(Screen screen)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Capacity", screen.Capacity);
               
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

        public async Task<Screen?> GetByIdAsync(int id)
        {
            Screen screen = null;

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
                            screen = new Screen
                            {
                                Id = reader.GetInt32(0),
                                Capacity = reader.GetInt32(1),
                               
                            }; 
                        }
                    }
                }
            }
            return screen;
        }

        public async Task UpdateAsync(Screen sala)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Capacity", sala.Capacity);
                


                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<List<Screen>> GetByMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }
    }


}