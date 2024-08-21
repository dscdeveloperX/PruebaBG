using DscApi.Models.Entity;

namespace DscApi.Interface
{
    public interface IFormulario
    {
        public Task<List<Formulario>> FormularioAll();
    }
}
