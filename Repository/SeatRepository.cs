using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class SeatRepository : ISeatRepository
    { 
        private readonly string _connectionString;

        public SeatRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Seat>> GetAllAsync()
        {
            var seats = new List<Seat>();
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
                            var seat = new Seat
                            {
                                Id = reader.GetInt32(0),
                                Status = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                Type = Enum.Parse<Seat.SeatType>(reader.GetString(3)), 
                                ScreenId = reader.GetInt32(4)
                            };
                            seats.Add(seat);
                        }
                    }
                }
            }
            return seats;
        }

        public async Task AddAsync(Seat seat)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", seat.Status);
                    command.Parameters.AddWithValue("@Price", seat.Price);
                    command.Parameters.AddWithValue("@Type", seat.Type);
                    command.Parameters.AddWithValue("@ScreenId", seat.ScreenId);

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

        public async Task<Seat?> GetByIdAsync(int id)
        {
            Seat seat = null;

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
                            seat = new Seat
                            {
                                Id = reader.GetInt32(0),
                                Status = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                Type = Enum.Parse<Seat.SeatType>(reader.GetString(3)), 
                                ScreenId = reader.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return seat;
        }

        public async Task UpdateAsync(Seat seat)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", seat.Status);
                    command.Parameters.AddWithValue("@Price", seat.Price);
                    command.Parameters.AddWithValue("@Type", seat.Type);
                    command.Parameters.AddWithValue("@ScreenId", seat.ScreenId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }
}