﻿namespace API.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Descripciones { get; set; }
        public int PrecioVenta { get; set; }
        public double Costo { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}