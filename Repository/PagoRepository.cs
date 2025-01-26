using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly string _connectionString;

        public PagoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Pago>> GetAllAsync()
        {
            var pagos = new List<Pago>();
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
                            var pago = new Pago
                            {
                                Id = reader.GetInt32(0),
                                PaymentStripeId = reader.GetString(1),
                                Estado = reader.GetString(2),
                                FechaPago = reader.GetDateTime(3),
                                UsuarioId = reader.GetInt32(4),
                                TicketId = reader.GetInt32(5)
                            };
                            pagos.Add(pago);
                        }
                    }
                }
            }
            return pagos;
        }

        public async Task AddAsync(Pago pago)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentStripeId", pago.PaymentStripeId);
                    command.Parameters.AddWithValue("@Estado", pago.Estado);
                    command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                    command.Parameters.AddWithValue("@UsuarioId", pago.UsuarioId);
                    command.Parameters.AddWithValue("@TicketId", pago.TicketId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<Pago?> GetByIdAsync(int id)
        {
            Pago pago = null;

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
                            pago = new Pago
                            {
                                Id = reader.GetInt32(0),
                                PaymentStripeId = reader.GetString(1),
                                Estado = reader.GetString(2),
                                FechaPago = reader.GetDateTime(3),
                                UsuarioId = reader.GetInt32(4),
                                TicketId = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return pago;
        }
    }
}