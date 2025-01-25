using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class SalaRepoitory : ISalaRepoitory
    { 
        private readonly string _connectionString;

        public SalaRepoitory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            var salas = new List<Sala>();
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
                            var sala = new Sala
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Capacidad = reader.GetInt32(2),
                                NFilas = reader.GetInt32(3),
                                NColumnas = reader.GetInt32(4),
                                Disponible = reader.GetBoolean(5),
                            }; 

                            salas.Add(sala);
                        }
                    }
                }
            }
            return salas;
        }

        public async Task AddAsync(Sala sala)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Nombre", sala.Nombre);
                    command.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                    command.Parameters.AddWithValue("@NFilas", sala.NFilas);
                    command.Parameters.AddWithValue("@NColumnas", sala.NColumnas);
                    command.Parameters.AddWithValue("@Disponible", sala.Disponible);

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

        public async Task<Sala?> GetByIdAsync(int id)
        {
            Sala sala = null;

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
                            sala = new Sala
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Capacidad = reader.GetInt32(2),
                                NFilas = reader.GetInt32(3),
                                NColumnas = reader.GetInt32(4),
                                Disponible = reader.GetBoolean(5),
                            }; 
                        }
                    }
                }
            }
            return sala;
        }

        public async Task UpdateAsync(Sala sala)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", sala.Nombre);
                    command.Parameters.AddWithValue("@Capacidad", sala.Capacidad);
                    command.Parameters.AddWithValue("@NFilas", sala.NFilas);
                    command.Parameters.AddWithValue("@NColumnas", sala.NColumnas);
                    command.Parameters.AddWithValue("@Disponible", sala.Disponible);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public interface ISalaRepoitory {}

}