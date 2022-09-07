namespace API.Model
{
    public class Venta
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public int IdUsuario { get; internal set; }
        public string? Descripciones { get; internal set; }
    }
}
