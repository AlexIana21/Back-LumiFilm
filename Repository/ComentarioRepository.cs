using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    { 
        private readonly string _connectionString;

        public ComentarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            var comentarios = new List<Comentario>();
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
                            var comentario = new Comentario
                            {
                                Id = reader.GetInt32(0),
                                Texto = reader.GetString(1),
                                Fecha = reader.GetDateTime(2),
                                UsuarioId = reader.GetInt32(3),
                                Puntuacion = reader.GetInt32(4)
                            }; 

                            comentarios.Add(comentario);
                        }
                    }
                }
            }
            return comentarios;
        }

        public async Task AddAsync(Comentario comentario)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Texto", comentario.Texto);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha);
                    command.Parameters.AddWithValue("@UsuarioId", comentario.UsuarioId);
                    command.Parameters.AddWithValue("@Puntuacion", comentario.Puntuacion);


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

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            Comentario comentario = null;

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
                            comentario = new Comentario
                            {
                                Id = reader.GetInt32(0),
                                Texto = reader.GetString(1),
                                Fecha = reader.GetDateTime(2),
                                UsuarioId = reader.GetInt32(3),
                                Puntuacion = reader.GetInt32(4)
                            }; 
                        }
                    }
                }
            }
            return comentario;
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Texto", comentario.Texto);
                    command.Parameters.AddWithValue("@Fecha", comentario.Fecha);
                    command.Parameters.AddWithValue("@UsuarioId", comentario.UsuarioId);
                    command.Parameters.AddWithValue("@Puntuacion", comentario.Puntuacion);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

   
}