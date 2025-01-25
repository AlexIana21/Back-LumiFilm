using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class SesionRepository : ISesionRepository
    { 
        private readonly string _connectionString;

        public SesionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Sesion>> GetAllAsync()
        {
            var sesiones = new List<Sesion>();
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
                            var sesion = new Sesion
                            {
                                    Id = reader.GetInt32(0),
                                    Dia = DateOnly.FromDateTime(reader.GetDateTime(1)), 
                                    Hora = TimeOnly.FromDateTime(reader.GetDateTime(2)), 
                                    PeliculaId = reader.GetInt32(3),
                                    SalaId = reader.GetInt32(4)
                            }; 

                            sesiones.Add(sesion);
                        }
                    }
                }
            }
            return sesiones;
        }

        public async Task AddAsync(Sesion sesion)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Dia", sesion.Dia);
                    command.Parameters.AddWithValue("@Hora", sesion.Hora);
                    command.Parameters.AddWithValue("@PeliculaId", sesion.PeliculaId);
                    command.Parameters.AddWithValue("@SalaId", sesion.SalaId);

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

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            Sesion sesion = null;

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
                            sesion = new Sesion
                            {
                                Id = reader.GetInt32(0),
                                Dia = DateOnly.FromDateTime(reader.GetDateTime(1)), 
                                Hora = TimeOnly.FromDateTime(reader.GetDateTime(2)), 
                                PeliculaId = reader.GetInt32(3),
                                SalaId = reader.GetInt32(4)
                            }; 
                        }
                    }
                }
            }
            return sesion;
        }

        public async Task UpdateAsync(Sesion sesion)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dia", sesion.Dia);
                    command.Parameters.AddWithValue("@Hora", sesion.Hora);
                    command.Parameters.AddWithValue("@PeliculaId", sesion.PeliculaId);
                    command.Parameters.AddWithValue("@SalaId", sesion.SalaId);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }

      public async Task<List<Sesion>> GetByMovieAsync(int movieId)
    {
        var sesiones = new List<Sesion>();
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
                        var sesion = new Sesion
                        {
                            Id = reader.GetInt32(0),
                            Dia = DateOnly.FromDateTime(reader.GetDateTime(1)),
                            Hora = TimeOnly.FromDateTime(reader.GetDateTime(2)),
                            PeliculaId = reader.GetInt32(3),
                            SalaId = reader.GetInt32(4)
                        };
                        sesiones.Add(sesion);
                    }
                }
            }
        }
        return sesiones;
    }
    }

}