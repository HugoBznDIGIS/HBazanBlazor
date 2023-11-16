
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.HbazanBlazorContext context = new DL.HbazanBlazorContext())
                {
                    var SP = (from objCategoria in context.Categoria
                              select new 
                              {
                                  IdCategoria = objCategoria.IdCategoria,
                                  Nombre = objCategoria.Nombre
                              }).ToList();

                    foreach (var itemCategoria in SP)
                    {
                        ML.Categoria categoria = new ML.Categoria();

                        categoria.IdCategoria = itemCategoria.IdCategoria;
                        categoria.Nombre = itemCategoria.Nombre;

                        list.Add(categoria);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
