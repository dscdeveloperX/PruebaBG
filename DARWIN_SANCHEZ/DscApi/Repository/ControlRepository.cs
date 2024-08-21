using DscApi.Interface;
using System.Data;
using Microsoft.Data.SqlClient;
using DscApi.Models.Entity;
using DscApi.Models.Request;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DscApi.Repository
{
    public class ControlRepository:IControl
    {
        private readonly string dscConnectionString;

        public ControlRepository(IConfiguration configuration)
        {
            dscConnectionString = configuration.GetConnectionString("dscconnectionstring");
        }

        public async Task<bool> ControlDelete(int controlId)
        {
            bool response = false;

            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_DeleteControl", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ControlId", SqlDbType.Int) { Value = controlId, Direction = ParameterDirection.Input });

                    await cnn.OpenAsync();

                    response = Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());


                }
            }

            return response;
        }

        public async Task<List<Control>> ControlSelect(ControlSelectRequest request)
        {

            //habilitar modificar objeto para controles de radio que tiene lista de opciones
            bool listaControlesGenerar = ((request.Estado != null || request.Estado == true) && request.ControlId == null && request.FormularioId != null);

            List<Control> response = new List<Control>();


            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_SelectControl", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FormularioId", SqlDbType.Int) { Value = (request.FormularioId.HasValue? (object)request.FormularioId:DBNull.Value), Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ControlId", SqlDbType.Int) { Value = (request.ControlId.HasValue ? (object)request.ControlId : DBNull.Value), Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.TinyInt) { Value = (request.Estado.HasValue ? (object)request.Estado : DBNull.Value), Direction = ParameterDirection.Input });
                    //
                    await cnn.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {

                        while (await dr.ReadAsync())
                        {

                            Control control = new Control()
                            {
                                ControlId = Convert.ToInt32(dr["ControlId"]),
                                FormularioId = Convert.ToInt32(dr["FormularioId"]),
                                Orden = Convert.ToInt32(dr["Orden"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                TipoId = dr["TipoId"].ToString(),
                                TipoNombre = dr["TipoNombre"].ToString(),
                                OpcionValor1 = dr["OpcionValor1"].ToString(),
                                OpcionTexto1 = dr["OpcionTexto1"].ToString(),
                                OpcionValor2 = dr["OpcionValor2"].ToString(),
                                OpcionTexto2 = dr["OpcionTexto2"].ToString(),
                                OpcionValor3 = dr["OpcionValor3"].ToString(),
                                OpcionTexto3 = dr["OpcionTexto3"].ToString(),
                                ValidRequired = Convert.ToBoolean(dr["ValidRequired"]),
                                ValidRequiredMsg = dr["ValidRequiredMsg"].ToString(),
                                ValidPattern = Convert.ToBoolean(dr["ValidPattern"]),
                                ValidPatternExpReg = dr["ValidPatternExpReg"].ToString(),
                                ValidPatternMsg = dr["ValidPatternMsg"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            };

                            //solo si genera controles considero agregar opciones para ser leidos por react
                            if (listaControlesGenerar)
                            {
                                //opciones
                                if (control.OpcionValor1.Length > 0) { control.Opciones.Add(new ControlOpcion() { Valor = control.OpcionValor1, Texto = control.OpcionTexto1 }); }
                                if (control.OpcionValor2.Length > 0) { control.Opciones.Add(new ControlOpcion() { Valor = control.OpcionValor2, Texto = control.OpcionTexto2 }); }
                                if (control.OpcionValor3.Length > 0) { control.Opciones.Add(new ControlOpcion() { Valor = control.OpcionValor3, Texto = control.OpcionTexto3 }); }
                                //validaciones
                                if (control.ValidRequired.HasValue) { 
                                    control.Validacion.RequiredMensaje = control.ValidRequiredMsg; 
                                }
                                if (control.ValidPattern.HasValue)
                                {
                                    control.Validacion.ControlPattern = new ControlPattern()
                                    {
                                        ExpresionRegular = control.ValidPatternExpReg,
                                        Mensaje = control.ValidPatternMsg
                                    };
                                }
                            }
                            response.Add(control);

                        }

                    }

                }
            }

            return response;
        }

        public async Task<bool> ControlInsert(ControlAddModRequest request)
        {
            bool response = false;

            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_InsertControl", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FormularioId", SqlDbType.Int) { Value = request.FormularioId, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Orden", SqlDbType.Int) { Value = request.Orden, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) {Value = request.Nombre, Size=100, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar) { Value = request.Descripcion, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@TipoId", SqlDbType.NVarChar) { Value = request.TipoId, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor1", SqlDbType.NVarChar) { Value = request.OpcionValor1, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto1", SqlDbType.NVarChar) { Value = request.OpcionTexto1, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor2", SqlDbType.NVarChar) { Value = request.OpcionValor2, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto2", SqlDbType.NVarChar) { Value = request.OpcionTexto2, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor3", SqlDbType.NVarChar) { Value = request.OpcionValor3, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto3", SqlDbType.NVarChar) { Value = request.OpcionTexto3, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidRequired", SqlDbType.TinyInt) { Value = request.ValidRequired, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidRequiredMsg", SqlDbType.NVarChar) { Value = request.ValidRequiredMsg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPattern", SqlDbType.TinyInt) { Value = request.ValidPattern, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPatternExpReg", SqlDbType.NVarChar) { Value = request.ValidPatternExpReg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPatternMsg", SqlDbType.NVarChar) { Value = request.ValidPatternMsg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.TinyInt) { Value = request.Estado, Direction = ParameterDirection.Input });

                    await cnn.OpenAsync();

                    response = Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());


                }
            }

            return response;
        }

        public async Task<bool> ControlUpdate(ControlAddModRequest request)
        {
            bool response = false;

            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_UpdateControl", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ControlId", SqlDbType.Int) { Value = request.ControlId, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Orden", SqlDbType.Int) { Value = request.Orden, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = request.Nombre, Size = 100, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar) { Value = request.Descripcion, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@TipoId", SqlDbType.NVarChar) { Value = request.TipoId, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor1", SqlDbType.NVarChar) { Value = request.OpcionValor1, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto1", SqlDbType.NVarChar) { Value = request.OpcionTexto1, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor2", SqlDbType.NVarChar) { Value = request.OpcionValor2, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto2", SqlDbType.NVarChar) { Value = request.OpcionTexto2, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionValor3", SqlDbType.NVarChar) { Value = request.OpcionValor3, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@OpcionTexto3", SqlDbType.NVarChar) { Value = request.OpcionTexto3, Size = 20, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidRequired", SqlDbType.TinyInt) { Value = request.ValidRequired, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidRequiredMsg", SqlDbType.NVarChar) { Value = request.ValidRequiredMsg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPattern", SqlDbType.TinyInt) { Value = request.ValidPattern, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPatternExpReg", SqlDbType.NVarChar) { Value = request.ValidPatternExpReg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@ValidPatternMsg", SqlDbType.NVarChar) { Value = request.ValidPatternMsg, Size = 200, Direction = ParameterDirection.Input });
                    cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.TinyInt) { Value = request.Estado, Direction = ParameterDirection.Input });


                    await cnn.OpenAsync();

                    response = Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());


                }
            }

            return response;
        }
    }
}
