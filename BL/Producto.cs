using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Producto
    {
        public static List<object> GetAll(string nombre)
        {
            ML.Producto producto = new ML.Producto();
            producto.Productos = new List<object>();

            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    var SP = (from objProd in context.Productos
                              join objCat in context.Categoria on objProd.IdCategoria equals objCat.IdCategoria
                              where objProd.Nombre.Contains(nombre == null ? "" : nombre)
                              select new
                              {
                                  IdProducto = objProd.IdProducto,
                                  Nombre = objProd.Nombre,
                                  Precio = objProd.Precio,
                                  Cantidad = objProd.Cantidad,
                                  IdCategoria = objCat.IdCategoria,
                                  NombreCategoria = objCat.Nombre
                              }).ToList();

                    foreach (var item in SP)
                    {
                        ML.Producto productoItem = new ML.Producto();

                        productoItem.IdProducto = item.IdProducto;
                        productoItem.Nombre = item.Nombre;
                        productoItem.Precio = item.Precio;
                        productoItem.Cantidad = item.Cantidad;
                        productoItem.IdCategoria = new ML.Categoria();
                        productoItem.IdCategoria.IdCategoria = item.IdCategoria;
                        productoItem.IdCategoria.Nombre = item.NombreCategoria;

                        producto.Productos.Add(productoItem);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return producto.Productos;
        }

        public static int Delete(int idProducto)
        {
            int affectedRow = 0;
            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    var query = (from objProducto in context.Productos
                                 where objProducto.IdProducto == idProducto
                                 select objProducto).FirstOrDefault();

                    context.Productos.Remove(query);
                    affectedRow = context.SaveChanges();

                    if (affectedRow == 1)
                    {
                        return affectedRow;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return affectedRow;
        }

        public static int Add(ML.Producto producto)
        {
            int affectedRow = 0;

            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    DL.Producto itemProducto = new DL.Producto();

                    itemProducto.Nombre = producto.Nombre;
                    itemProducto.Precio = producto.Precio;
                    itemProducto.Cantidad = producto.Cantidad;
                    itemProducto.IdCategoria = producto.IdCategoria.IdCategoria;

                    context.Productos.Add(itemProducto);
                    affectedRow = context.SaveChanges();

                    if (affectedRow == 1)
                    {
                        return affectedRow;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return affectedRow;
        }

        public static object GetById(int idProducto)
        {
            ML.Producto producto = new ML.Producto();
            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    var query = (from objProducto in context.Productos
                                 join objCategoria in context.Categoria on objProducto.IdCategoria equals objCategoria.IdCategoria
                                 where objProducto.IdProducto == idProducto
                                 select new
                                 {
                                     IdProducto = objProducto.IdProducto,
                                     Nombre = objProducto.Nombre,
                                     Precio = objProducto.Precio,
                                     Cantidad = objProducto.Cantidad,
                                     IdCategoria = objCategoria.IdCategoria,
                                     NombreCategoria = objCategoria.Nombre
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Precio = query.Precio;
                        producto.Cantidad = query.Cantidad;
                        producto.IdCategoria = new ML.Categoria();
                        producto.IdCategoria.IdCategoria = query.IdCategoria;
                        producto.IdCategoria.Nombre = query.NombreCategoria;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public static int Update(ML.Producto producto)
        {
            int affectedRow = 0;
            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    var query = (from objProducto in context.Productos
                                 where objProducto.IdProducto == producto.IdProducto
                                 select objProducto).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.Precio = producto.Precio;
                        query.Cantidad = producto.Cantidad;
                        query.IdCategoria = producto.IdCategoria.IdCategoria;

                        affectedRow = context.SaveChanges();

                        if (affectedRow > 0)
                        {
                            return affectedRow;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return affectedRow;
        }
    }
}