using AccesoriosMoviles.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccesoriosMoviles.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pProducto);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
             var producto = await dbContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                producto.IdCategoria = pProducto.IdCategoria;
                producto.Nombre = pProducto.Nombre;
                producto.Precio = pProducto.Precio;
                producto.Imagen = pProducto.Imagen;
                producto.Descripcion = pProducto.Descripcion;
             dbContexto.Update(producto);
             result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var producto = await dbContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                dbContexto.Producto.Remove(producto);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var dbContexto = new DBContexto())
            {
                producto = await dbContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
            }
            return producto;
        }

        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var dbContexto = new DBContexto())
            {
                productos = await dbContexto.Producto.ToListAsync();
            }
            return productos;
        }

        internal static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProducto.Id);
            if (pProducto.IdCategoria> 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pProducto.IdCategoria);
            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProducto.Nombre));
            if (!string.IsNullOrWhiteSpace(pProducto.Precio))
                pQuery = pQuery.Where(s => s.Precio.Contains(pProducto.Precio));
            if (!string.IsNullOrWhiteSpace(pProducto.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pProducto.Imagen));
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProducto.Descripcion));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var Productos = new List<Producto>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                Productos = await select.ToListAsync();
            }
            return Productos;
        }
        public static async Task<List<Producto>> BuscarIncluirCategoriasAsync(Producto pProducto)
        {
            var productos = new List<Producto>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto).Include(s => s.Categoria).AsQueryable();
                productos = await select.ToListAsync();
            }
            return productos;
        }

    }
}








