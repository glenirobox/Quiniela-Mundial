public class Usuario
{
    public int Id { get; set;}
    public string Nombre { get; set;} = string.Empty; //string.Empty; para que el atributo nazca inicializado con un valor seguro
    public string PaisFavorito { get; set;} = string.Empty;
    public int Puntos { get; set;}

}