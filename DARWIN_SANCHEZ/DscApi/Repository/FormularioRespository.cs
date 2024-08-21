using DscApi.Interface;
using DscApi.Models.Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DscApi.Repository
{
    public class FormularioRespository : IFormulario
    {

        private readonly string dscConnectionString;

        public FormularioRespository(IConfiguration configuration)
        {
            dscConnectionString = configuration.GetConnectionString("dscconnectionstring");
        }

        public async Task<List<Formulario>> FormularioAll()
        {
            List<Formulario> response = new List<Formulario>();

            using (SqlConnection cnn = new SqlConnection(dscConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dsc_sp_SelectFormulario", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //
                    await cnn.OpenAsync();

                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {

                        while (await dr.ReadAsync())
                        {
                            response.Add(
                                new Formulario()
                                {
                                    FormularioId = dr["FormularioId"].ToString(),
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
