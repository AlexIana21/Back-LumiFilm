using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class AsientoRepository : IAsientoRepository
    { 
        private readonly string _connectionString;

        public AsientoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Asiento>> GetAllAsync()
        {
            var asientos = new List<Asiento>();
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
                            var asiento = new Asiento
                            {
                                Id = reader.GetInt32(0),
                                Fila = reader.GetChar(1),
                                Columna = reader.GetInt32(2),
                                Estado = reader.GetString(3),
                                Precio = reader.GetDouble(4),
                                EsVip = reader.GetBoolean(5),
                                SalaId = reader.GetInt32(6)
                            };
                            asientos.Add(asiento);
                        }
                    }
                }
            }
            return asientos;
        }

        public async Task AddAsync(Asiento asiento)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fila", asiento.Fila);
                    command.Parameters.AddWithValue("@Columna", asiento.Columna);
                    command.Parameters.AddWithValue("@Estado", asiento.Estado);
                    command.Parameters.AddWithValue("@Precio", asiento.Precio);
                    command.Parameters.AddWithValue("@EsVip", asiento.EsVip);
                    command.Parameters.AddWithValue("@SalaId", asiento.SalaId);

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

        public async Task<Asiento?> GetByIdAsync(int id)
        {
            Asiento asiento = null;

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
                            asiento = new Asiento
                            {
                                Id = reader.GetInt32(0),
                                Fila = reader.GetChar(1),
                                Columna = reader.GetInt32(2),
                                Estado = reader.GetString(3),
                                Precio = reader.GetDouble(4),
                                EsVip = reader.GetBoolean(5),
                                SalaId = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return asiento;
        }

        public async Task UpdateAsync(Asiento asiento)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", asiento.Id);
                    command.Parameters.AddWithValue("@Fila", asiento.Fila);
                    command.Parameters.AddWithValue("@Columna", asiento.Columna);
                    command.Parameters.AddWithValue("@Estado", asiento.Estado);
                    command.Parameters.AddWithValue("@Precio", asiento.Precio);
                    command.Parameters.AddWithValue("@EsVip", asiento.EsVip);
                    command.Parameters.AddWithValue("@SalaId", asiento.SalaId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}