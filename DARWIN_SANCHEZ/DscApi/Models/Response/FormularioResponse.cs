using DscApi.Models.Entity;

namespace DscApi.Models.Response
{
    public class FormularioResponse
    {
        public int ErrorCodigo { get; set; }
        public string ErrorMensaje { get; set; }
        public List<Formulario> Formularios { get; set; } = new List<Formulario>();

    }
}
