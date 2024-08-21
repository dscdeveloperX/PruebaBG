using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DscApi.Interface;
using DscApi.Repository;
using DscApi.Models.Response;
using DscApi.Models.Entity;
using DscApi.Models.Request;

namespace DscApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("dsccors")]
    public class FormularioController : ControllerBase
    {
        private readonly IFormulario _formularioRepository;
        public FormularioController(IFormulario formularioRepository)
        {
            _formularioRepository = formularioRepository;
        }


        [HttpGet("all")]
        public async Task<ActionResult<FormularioResponse>> GetAll()
        {
            FormularioResponse response = new FormularioResponse();
            List<Formulario> data = new List<Formulario>();

            try
            {
                data = await _formularioRepository.FormularioAll();
                response.ErrorCodigo = 0;
                response.ErrorMensaje = "Transacion exitosa";
                response.Formularios = data;
            }
            catch (Exception ex)
            {

                response.ErrorCodigo = 1000;
                response.ErrorMensaje = "Error: " + ex.Message;
                response.Formularios = data;
            }
            return response;
        }

    }
}
