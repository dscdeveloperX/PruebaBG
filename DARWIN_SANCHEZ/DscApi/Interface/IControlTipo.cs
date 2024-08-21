using DscApi.Models.Entity;

namespace DscApi.Interface
{
    public interface IControlTipo
    {
        public Task<List<ControlTipo>> ControlTipoAll();

    }
}
