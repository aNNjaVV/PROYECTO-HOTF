using API_HOTF_1.Modelos;
using System.Data.SqlClient;

namespace API_HOTF_1.DAO
{
    public class MatriculaDAO
    {
        private readonly string cad_conexion;

        public MatriculaDAO(IConfiguration config)
        {
            cad_conexion = config.GetConnectionString("cn1");
        }

        public List<Matricula> ListarComentarios() 
        {
            var lista = new List<Matricula>();

            SqlDataReader dr = 
                SqlHelper.ExecuteReader(cad_conexion, "PA_COMENTARIOS_API");

            while (dr.Read())
            {
                lista.Add(new Matricula() { 
                    codigo = dr.GetString(0),
                    curso = dr.GetString(1),
                    atendidoPor = dr.GetString(2),
                    estado = dr.GetString(3)
                });
            }
            dr.Close();

            return lista;
        }

        public string GrabarComentarios(Matricula obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_INSERTAR_COMENTARIOS_API",
                       obj.codigo, obj.curso, obj.atendidoPor = "Maria Benitez Lopez",obj.estado = "Registrado");
                //
                //mensaje = $"El Comentario de {obj.codigo} fue registrado correctamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }



      

    }
}
