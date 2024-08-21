using Azure.Core;
using DscApi.Interface;
using DscApi.Models.Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DscApi.Repository
{
    public class ControlTipoRepository : IControlTipo
    {

        private readonly string dscConnectionString;

        public ControlTipoRepository(IConfiguration configuration)
        {
            dscConnectionString = configuration.GetConnectionString("dscconnectionstring");
        }

        public async Task<List<ControlTipo>> ControlTipoAll()
        {
            List<ControlTipo> response = new List<ControlTipo>();

            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_SelectControlTipo", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //
                    await cnn.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {

                        while (await dr.ReadAsync())
                        {
                            response.Add(
                                new ControlTipo()
                                {
                                    ControlTipoId = dr["ControlTipoId"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                );
                        }

                    }

                }
            }

            return response;
        }
    }
}
