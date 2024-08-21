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
    public class ControlTipoController : ControllerBase
    {


        private readonly IControlTipo _controlTipoRepository;
        public ControlTipoController(IControlTipo controlTipoRepository)
        {
            _controlTipoRepository = controlTipoRepository;
        }


        [HttpGet("all")]
        public async Task<ActionResult<ControlTipoResponse>> GetAll()
        {
            ControlTipoResponse response = new ControlTipoResponse();
            List<ControlTipo> data = new List<ControlTipo>();

            try
            {
                data = await _controlTipoRepository.ControlTipoAll();
                response.ErrorCodigo = 0;
                response.ErrorMensaje = "Transacion exitosa";
                response.ControlTipos = data;
            }
            catch (Exception ex)
            {

                response.ErrorCodigo = 1000;
                response.ErrorMensaje = "Error: " + ex.Message;
                response.ControlTipos = data;
            }
            return response;
        }

    }
}
