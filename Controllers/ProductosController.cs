using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diaD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace diaD.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoController(GeneralContext productoContex)
        {
            Context = productoContex; 
        }

        private GeneralContext Context;
        // GET api/values

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Context.Producto.Include(x => x.Categoria).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            return Context.Producto.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Producto value)
        {
            Context.Producto.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Producto value)
        {
            var Productos = Context.Producto.Find(id);
            Productos.Precio = value.Precio;
            Productos.Titulo = value.Titulo;
            Productos.Descripcion = value.Descripcion;
            Productos.CategoriaId = value.CategoriaId;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var Productos = Context.Producto.Find(id);
            if(Productos == null)
            {
               NotFound();
            }
            else 
            {
            Context.Producto.Remove(Productos);
            Context.SaveChanges();
            }
        }
    }
}
