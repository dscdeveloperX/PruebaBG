namespace DscApi.Models.Entity
{
    public class Control
    {
        public int ControlId { get; set; }
        public int FormularioId { get; set; }
        public int Orden { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoId { get; set; }
        public string TipoNombre { get; set; } = "";
        public string OpcionValor1 { get; set; }
        public string OpcionTexto1 { get; set; }
        public string OpcionValor2 { get; set; }
        public string OpcionTexto2 { get; set; }
        public string OpcionValor3 { get; set; }
        public string OpcionTexto3 { get; set; }
        public List<ControlOpcion>? Opciones { get; set; }= new List<ControlOpcion>();
        public bool? ValidRequired { get; set; }
        public string ValidRequiredMsg { get; set; }
        public bool? ValidPattern { get; set; }
        public string ValidPatternExpReg { get; set; }
        public string ValidPatternMsg { get; set; }
        public ControlValidacion Validacion { get; set; } = new ControlValidacion();
        public bool Estado { get; set; } = true;
    }
}
