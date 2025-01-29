using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

    public async Task<List<Order>> GetAllAsync()
    {
    var orders = new List<Order>();
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
                    var order = new Order
                    {
                        Id = reader.GetInt32(0),
                        PaymentStripeId = reader.GetString(1),
                        Price = reader.GetDouble(2),
                        Status = Enum.Parse<Order.OrderStatus>(reader.GetString(3)),
                        Date = reader.GetDateTime(4),
                        UserId = reader.GetInt32(5),
                        SessionId = reader.GetInt32(6)
                    };
                    orders.Add(order);
                }
            }
        }
    }
        return orders;
    }


        public async Task AddAsync(Order order)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentStripeId", order.PaymentStripeId);
                    command.Parameters.AddWithValue("@Price", order.Price);
                    command.Parameters.AddWithValue("@Status", order.Status);
                    command.Parameters.AddWithValue("@Date", order.Date);
                    command.Parameters.AddWithValue("@UserId", order.UserId);
                    command.Parameters.AddWithValue("@SessionId", order.SessionId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<Order?> GetByIdAsync(int id)
        {
            Order order = null;

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
                            order = new Order
                            {
                                Id = reader.GetInt32(0),
                                PaymentStripeId = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                Status = Enum.Parse<Order.OrderStatus>(reader.GetString(3)), 
                                Date = reader.GetDateTime(4),
                                UserId = reader.GetInt32(5),
                                SessionId = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return order;
        }
    }
}