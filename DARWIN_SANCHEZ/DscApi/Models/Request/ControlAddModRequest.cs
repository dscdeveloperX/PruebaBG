namespace DscApi.Models.Request
{
    public class ControlAddModRequest
    {
        public int? ControlId { get; set; } = 0;
        public int? FormularioId { get; set; } = 0;
        public int Orden { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoId { get; set; }
        public string OpcionValor1 { get; set; }
        public string OpcionTexto1 { get; set; }
        public string OpcionValor2 { get; set; }
        public string OpcionTexto2 { get; set; }
        public string OpcionValor3 { get; set; }
        public string OpcionTexto3 { get; set; }
        public bool? ValidRequired { get; set; }
        public string ValidRequiredMsg { get; set; }
        public bool? ValidPattern { get; set; }
        public string ValidPatternExpReg { get; set; }
        public string ValidPatternMsg { get; set; }
        public bool Estado { get; set; } = true;
    }
}
