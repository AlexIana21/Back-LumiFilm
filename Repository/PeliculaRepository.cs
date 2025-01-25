using Models;
using MySql.Data.MySqlClient;

namespace Reto_Back.Repositories
{
    public class PeliculaRepoitory : IPeliculaRepoitory
    { 
        private readonly string _connectionString;

        public PeliculaRepoitory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Pelicula>> GetAllAsync()
        {
            var peliculas = new List<Pelicula>();
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
                            var pelicula = new Pelicula
                            {
                                Id = reader.GetInt32(0),
                                Titulo = reader.GetString(1),
                                Sinopsis = reader.GetString(2),
                                Duracion = reader.GetInt32(3),
                                Clasificacion = reader.GetInt32(4),
                                Genero = reader.GetString(5),
                                Direccion = reader.GetString(6),
                                Imagen = reader.GetString(7)
                            }; 

                            peliculas.Add(pelicula);
                        }
                    }
                }
            }
            return peliculas;
        }

        public async Task AddAsync(Pelicula pelicula)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
                    command.Parameters.AddWithValue("@Sinopsis", pelicula.Sinopsis);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@Clasificacion", pelicula.Clasificacion);
                    command.Parameters.AddWithValue("@Genero", pelicula.Genero);
                    command.Parameters.AddWithValue("@Direccion", pelicula.Direccion);
                    command.Parameters.AddWithValue("@Imagen", pelicula.Imagen);

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

        public async Task<Pelicula?> GetByIdAsync(int id)
        {
            Pelicula pelicula = null;

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
                            pelicula = new Pelicula
                            {
                                Id = reader.GetInt32(0),
                                Titulo = reader.GetString(1),
                                Sinopsis = reader.GetString(2),
                                Duracion = reader.GetInt32(3),
                                Clasificacion = reader.GetInt32(4),
                                Genero = reader.GetString(5),
                                Direccion = reader.GetString(6),
                                Imagen = reader.GetString(7)
                            }; 
                        }
                    }
                }
            }
            return pelicula;
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
                    command.Parameters.AddWithValue("@Sinopsis", pelicula.Sinopsis);
                    command.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
                    command.Parameters.AddWithValue("@Clasificacion", pelicula.Clasificacion);
                    command.Parameters.AddWithValue("@Genero", pelicula.Genero);
                    command.Parameters.AddWithValue("@Direccion", pelicula.Direccion);
                    command.Parameters.AddWithValue("@Imagen", pelicula.Imagen);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

    public interface IPeliculaRepoitory
    {
        Task<List<Pelicula>> GetAllAsync();
    }
}