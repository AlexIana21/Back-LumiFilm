using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class TicketRepository : ITicketRepository
    { 
        private readonly string _connectionString;

        public TicketRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            var tickets = new List<Ticket>();
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
                            var ticket = new Ticket
                            {
                                Id = reader.GetInt32(0),
                                UsuarioId = reader.GetInt32(1),
                                SesionId = reader.GetInt32(2),
                                Asiento = reader.GetInt32(3),
                                PrecioFinal = reader.GetDouble(4)
                            }; 

                            tickets.Add(ticket);
                        }
                    }
                }
            }
            return tickets;
        }

        public async Task AddAsync(Ticket ticket)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@UsuarioId", ticket.UsuarioId);
                    command.Parameters.AddWithValue("@SesionId", ticket.SesionId);
                    command.Parameters.AddWithValue("@Asiento", ticket.Asiento);
                    command.Parameters.AddWithValue("@PrecioFinal", ticket.PrecioFinal);

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

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            Ticket ticket = null;

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
                            ticket = new Ticket
                            {
                            Id = reader.GetInt32(0),
                                UsuarioId = reader.GetInt32(1),
                                SesionId = reader.GetInt32(2),
                                Asiento = reader.GetInt32(3),
                                PrecioFinal = reader.GetDouble(4)
                            }; 
                        }
                    }
                }
            }
            return ticket;
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", ticket.UsuarioId);
                    command.Parameters.AddWithValue("@SesionId", ticket.SesionId);
                    command.Parameters.AddWithValue("@Asiento", ticket.Asiento);
                    command.Parameters.AddWithValue("@PrecioFinal", ticket.PrecioFinal);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public interface ITicketRepoitory {}
}