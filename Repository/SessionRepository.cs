using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class SessionRepository : ISessionRepository
    { 
        private readonly string _connectionString;

        public SessionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            var sessions = new List<Session>();
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
                            var session = new Session
                            {
                                    Id = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    MovieId = reader.GetInt32(2),
                                    ScreenId = reader.GetInt32(3)
                            }; 

                            sessions.Add(session);
                        }
                    }
                }
            }
            return sessions;
        }

        public async Task AddAsync(Session session)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Date", session.Date);
                    command.Parameters.AddWithValue("@MovieId", session.MovieId);
                    command.Parameters.AddWithValue("@ScreenId", session.ScreenId);
             

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

        public async Task<Session?> GetByIdAsync(int id)
        {
            Session session = null;

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
                            session = new Session
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetDateTime(1),
                                MovieId = reader.GetInt32(2),
                                ScreenId = reader.GetInt32(3)
                            }; 
                        }
                    }
                }
            }
            return session;
        }

        public async Task UpdateAsync(Session session)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", session.Date);
                    command.Parameters.AddWithValue("@MovieId", session.MovieId);
                    command.Parameters.AddWithValue("@ScreenId", session.ScreenId);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }

      public async Task<List<Session>> GetByMovieAsync(int movieId)
    {
        var sessions = new List<Session>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            string query = "";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MovieId", movieId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var session = new Session
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            MovieId = reader.GetInt32(2),
                            ScreenId = reader.GetInt32(3)
                        };
                        sessions.Add(session);
                    }
                }
            }
        }
        return sessions;
    }
    }

}