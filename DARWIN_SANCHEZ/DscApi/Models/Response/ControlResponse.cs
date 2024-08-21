using DscApi.Models.Entity;

namespace DscApi.Models.Response
{
    public class ControlResponse
    {
        public int ErrorCodigo { get; set; }
        public string ErrorMensaje { get; set; }
        public List<Control> Controles { get; set; } = new List<Control>();
    }
}
