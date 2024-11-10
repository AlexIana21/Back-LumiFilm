namespace Models;
public class Pago {
    private static int contadorId = 1;
    public int Id {get; private set;} = 1;
    public string Nombre  { get; set; }
    public string Apellido  { get; set; }
    public int Telefono   { get; set; }
    public string Mail  { get; set; }

    public Pago(string nombre, string apellido, int telefono, string mail) {
      Id = contadorId++;
      Nombre = nombre;
      Apellido = apellido;
      Telefono = telefono;
      Mail = mail;
    }
}