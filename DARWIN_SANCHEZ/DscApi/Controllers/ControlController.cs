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
    public class ControlController : ControllerBase
    {
        private readonly IControl _controlRepository;
    public ControlController(IControl controlRepository)
    {
        _controlRepository = controlRepository;
    }

    [HttpPost("Select")]
    public async Task<ActionResult<ControlResponse>> PostSelect(ControlSelectRequest request)
    {
        ControlResponse response = new ControlResponse();
        List<Control> data = new List<Control>();


        try
        {
            data = await _controlRepository.ControlSelect(request);
            response.ErrorCodigo = 0;
            response.ErrorMensaje = "Transacion exitosa";
            response.Controles = data;
        }
        catch (Exception ex)
        {

            response.ErrorCodigo = 1000;
            response.ErrorMensaje = "Error: " + ex.Message;
            response.Controles = data;
        }
        return response;
    }


   
    [HttpPost("Post")]
    public async Task<ActionResult<ControlResponse>> Post([FromBody] ControlAddModRequest request)
    {
        ControlResponse response = new ControlResponse();
        List<Control> data = new List<Control>();

        try
        {
            if (!await _controlRepository.ControlInsert(request))
            {
                throw new Exception("no se insertaron registros");
            }
            response.ErrorCodigo = 0;
            response.ErrorMensaje = "Transacion exitosa";
            response.Controles = data;
        }
        catch (Exception ex)
        {

            response.ErrorCodigo = 1010;
            response.ErrorMensaje = "Error: " + ex.Message;
            response.Controles = data;
        }
        return response;
    }



    [HttpPut("Put")]
    public async Task<ActionResult<ControlResponse>> Put([FromBody] ControlAddModRequest request)
    {
        ControlResponse response = new ControlResponse();
        List<Control> data = new List<Control>();

        try
        {
            if (!await _controlRepository.ControlUpdate(request))
            {
                throw new Exception("no se modifico el registro");
            }
            response.ErrorCodigo = 0;
            response.ErrorMensaje = "Transacion exitosa";
            response.Controles = data;
        }
        catch (Exception ex)
        {

            response.ErrorCodigo = 1002;
            response.ErrorMensaje = "Error: " + ex.Message;
            response.Controles = data;
        }
        return response;
    }

    [HttpDelete("Detele/{controlId:int}")]
    public async Task<ActionResult<ControlResponse>> Delete( int controlId)
    {
        ControlResponse response = new ControlResponse();
        List<Control> data = new List<Control>();

        try
        {
            if (!await _controlRepository.ControlDelete(controlId))
            {
                throw new Exception("no se elimino registro");
            }
            response.ErrorCodigo = 0;
            response.ErrorMensaje = "Transacion exitosa";
            response.Controles = data;
        }
        catch (Exception ex)
        {

            response.ErrorCodigo = 1003;
            response.ErrorMensaje = "Error: " + ex.Message;
            response.Controles = data;
        }
        return response;
    }



}
}
