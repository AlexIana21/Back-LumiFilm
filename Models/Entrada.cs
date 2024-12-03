using Utils;

namespace Models
{
    public class Entrada
    {
        private static int contadorId = 1;

        public int Id { get; set; }
        public string Tipo { get; set; }
        public double Precio { get; set; }
        public Entrada(string tipo, double precio)
        {
            try
            {
                if (precio < 0)
                {
                    throw new ArgumentException("Error: El precio no puede ser negativo");
                }

                Id = contadorId++;
                Tipo = tipo;
                Precio = precio;
            }
            catch (ArgumentException ex)
            {
               
                Logger.LogError(ex);
                throw; 
            }
        }
    }
}