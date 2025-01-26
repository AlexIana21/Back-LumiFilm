using Models;
using MySql.Data.MySqlClient;


namespace Reto_Back.Repositories
{
    public class AdminRepository : IAdminRespository
    { 
        private readonly string _connectionString;

        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            var admins = new List<Admin>();
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
                            var admin = new Admin
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Mail = reader.GetString(3),
                                Password = reader.GetString(4)
                            }; 

                            admins.Add(admin);
                        }
                    }
                }
            }
            return admins;
        }

        public async Task AddAsync(Admin admin)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Nombre", admin.Nombre);
                    command.Parameters.AddWithValue("@Apellido", admin.Apellido);
                    command.Parameters.AddWithValue("@Mail", admin.Mail);
                    command.Parameters.AddWithValue("@Password", admin.Password);

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

        public async Task<Admin?> GetByIdAsync(int id)
        {
            Admin admin = null;

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
                            admin = new Admin
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Mail = reader.GetString(3),
                                Password = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return admin;
        }

        public async Task UpdateAsync(Admin admin)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", admin.Nombre);
                    command.Parameters.AddWithValue("@Apellido", admin.Apellido);
                    command.Parameters.AddWithValue("@Mail", admin.Mail);
                    command.Parameters.AddWithValue("@Password", admin.Password);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}