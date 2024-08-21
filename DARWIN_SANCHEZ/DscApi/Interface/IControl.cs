using DscApi.Models.Entity;
using DscApi.Models.Request;

namespace DscApi.Interface
{
    public interface IControl
    {
        public Task<List<Control>> ControlSelect(ControlSelectRequest request);
        public Task<bool> ControlInsert(ControlAddModRequest request);
        public Task<bool> ControlUpdate(ControlAddModRequest request);
        public Task<bool> ControlDelete(int controlId);

    }
}
