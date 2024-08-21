namespace DscApi.Models.Request
{
    public class ControlSelectRequest
    {
        public int? FormularioId { get; set; } = null;
        public int? ControlId { get; set; } = null;
        public bool? Estado { get; set; }=null;

    }
}
