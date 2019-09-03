using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using diaD.Models;
using Microsoft.EntityFrameworkCore;

namespace diaD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public CategoriasController(GeneralContext ProductContext)
        {
            Context = ProductContext;
        }
        private GeneralContext Context;

        // GET api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return Context.Categoria.Include(x => x.Productos).ToList();
        }


        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            return Context.Categoria.Find(id);
        }


        // POST api/Product
        [HttpPost]
        public void Post([FromBody] Categoria value)
        {
            Context.Categoria.Add(value);
            Context.SaveChanges();
        }


        // PUT api/Product/5

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria value)
        {
            var Categoria = Context.Categoria.Find(id);
            if (Categoria != null)
            {
                Categoria.Titulo = value.Titulo;
                Categoria.Productos = value.Productos;
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = Context.Categoria.Find(id);
            if (categoria != null)
            {
                Context.Remove(categoria);
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
