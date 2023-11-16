namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Categoria IdCategoria { get; set; }
        public object? ProductoById { get; set; }
        public List<object>? Productos { get; set; }
    }
}