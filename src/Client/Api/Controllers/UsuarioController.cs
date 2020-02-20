using Microsoft.AspNetCore.Mvc;
using Models.Forms;
using Services.Interfaces;
using System;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            IUsuarioService usuarioService
        )
        {
            _usuarioService = usuarioService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usuarioService.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _usuarioService.Get(id);

            return Ok(result);
        }



        [HttpPost]
        public IActionResult Create(UsuarioForm model)
        {
            try
            {
                var result = _usuarioService.Create(model);

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }


        [HttpPut]
        public IActionResult Update(UsuarioForm model)
        {
            try
            {
                _usuarioService.Update(model);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }


        [HttpDelete]
        public IActionResult Delete(int idLibro)
        {
            try
            {
                _usuarioService.Remove(idLibro);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }
    }
}