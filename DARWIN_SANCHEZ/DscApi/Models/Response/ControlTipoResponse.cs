using DscApi.Models.Entity;

namespace DscApi.Models.Response
{
    public class ControlTipoResponse
    {
        public int ErrorCodigo { get; set; }
        public string ErrorMensaje { get; set; }
        public List<ControlTipo> ControlTipos { get; set; } = new List<ControlTipo>();
    }
}
