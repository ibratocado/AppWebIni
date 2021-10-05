using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWebIni.Models.DBWeb;
using AppWebIni.Models.DBWeb.Respons;

namespace AppWebIni.Controllers.DBWeb
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            Respon oRepuesta = new Respon();
            try
            {
                using (webContext db = new webContext())
                {
                    oRepuesta.Data= db.Productos.ToList();
                
                }

            }
            catch (Exception ex)
            {
                oRepuesta.Estado = 404;
                oRepuesta.Mensage = ex.Message;
            }

            return Ok(oRepuesta);
        }

        #endregion

        #region post
        [HttpPost]
        public IActionResult Add(ProductosRequest oModel)
        {
            Respon oRepuesta = new Respon();
            try
            {
                using (webContext db = new webContext())
                {
                    Producto oProducto = new Producto();
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.Precio = oModel.Precio;
                    oProducto.PrecioPub = oModel.PrecioPub;
                    oProducto.Cantidad = oModel.Cantidad;
                    db.Productos.AddAsync(oProducto);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                oRepuesta.Estado = 404;
                oRepuesta.Mensage = ex.Message;
            }

            return Ok(oRepuesta);
        }
        #endregion

        #region put
        [HttpPut]
        public IActionResult Update(ProductosRequest oModel)
        {
            Respon oRepuesta = new Respon();
            try
            {
                using (webContext db = new webContext())
                {
                    Producto oProducto = db.Productos.Find(oModel.Id);
                    oProducto.Nombre = oModel.Nombre;
                    oProducto.Precio = oModel.Precio;
                    oProducto.PrecioPub = oModel.PrecioPub;
                    oProducto.Cantidad = oModel.Cantidad;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                oRepuesta.Estado = 404;
                oRepuesta.Mensage = ex.Message;
            }

            return Ok(oRepuesta);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Respon oRepuesta = new Respon();
            try
            {
                using (webContext db = new webContext())
                {
                    Producto oProducto = db.Productos.Find(Id);

                    db.Remove(oProducto);
                    db.SaveChanges();




                }

            }
            catch (Exception ex)
            {
                oRepuesta.Estado = 404;
                oRepuesta.Mensage = ex.Message;
            }

            return Ok(oRepuesta);
        }
        #endregion
    }
}
