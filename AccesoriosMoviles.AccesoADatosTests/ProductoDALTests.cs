using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccesoriosMoviles.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoriosMoviles.EntidadesDeNegocio;
namespace AccesoriosMoviles.AccesoADatos.Tests
{
    [TestClass()]
    public class ProductoDALTests
    {
        private static Producto productoInicial = new Producto { Id = 7, IdCategoria = 1, Nombre = "Protectores", Precio = "12", Imagen = "Protector", Descripcion = "Para telefono Alcatel" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {

            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "Protectores";
            producto.Precio = "12";
            producto.Imagen = "Protector";
            producto.Descripcion = "Para telefono Alcatel";
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);


        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "Protectores";
            producto.Precio = "12";
            producto.Imagen = "Protector";
            producto.Descripcion = "Para telefono Alcatel";
            int result = await ProductoDAL.ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
            
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.Id, resultProducto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProductos = await ProductoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "p";
            producto.Precio = "12";
            producto.Imagen = "p";
            producto.Descripcion = "p";
            producto.Top_Aux = 10;
            var resultProductos = await ProductoDAL.BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirCategoriasAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Nombre = "p";
            producto.Precio = "12";
            producto.Imagen = "p";
            producto.Descripcion = "p";
            producto.Top_Aux = 10;
            var resultProductos = await ProductoDAL.BuscarIncluirCategoriasAsync(producto);
            Assert.AreNotEqual(0, resultProductos.Count);
            var ultimoProducto = resultProductos.FirstOrDefault();
            Assert.IsTrue(ultimoProducto.Categoria != null && producto.IdCategoria == ultimoProducto.Categoria.Id);
        }

      

        [TestMethod()]
        public async Task T9EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            int result = await ProductoDAL.EliminarAsync(producto);
            Assert.AreNotEqual(0, result);
        }
    }
}