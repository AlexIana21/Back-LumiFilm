using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = new List<User>();
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
                            var user = new User
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Mail = reader.GetString(4),
                                Password = reader.GetString(5)
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }

        public async Task AddAsync(User user)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Nombre", user.Nombre);
                    command.Parameters.AddWithValue("@Apellido", user.Apellido);
                    command.Parameters.AddWithValue("@Telefono", user.Telefono);
                    command.Parameters.AddWithValue("@Mail", user.Mail);
                    command.Parameters.AddWithValue("@Password", user.Password);
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

        public async Task<User?> GetByIdAsync(int id)
        {
            User user = null;

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
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Mail = reader.GetString(4),
                                Password = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", user.Nombre);
                    command.Parameters.AddWithValue("@Apellido", user.Apellido);
                    command.Parameters.AddWithValue("@Telefono", user.Telefono);
                    command.Parameters.AddWithValue("@Mail", user.Mail);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}