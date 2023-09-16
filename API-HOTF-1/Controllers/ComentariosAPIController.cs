using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using API_HOTF_1.Modelos;
using API_HOTF_1.DAO;

namespace API_HOTF_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosAPIController : ControllerBase
    {
        private readonly MatriculaDAO dao_comentarios;

        public ComentariosAPIController(MatriculaDAO _dao)
        {
            dao_comentarios = _dao;
        }

        // GET: api/<MedicosAPIController>
        [HttpGet("GetComentario")]
        public List<Matricula> Get()
        {
            return dao_comentarios.ListarComentarios();
        }

        // GET api/<MedicosAPIController>/5
        [HttpGet("GetComentario/{id}")]
        public Matricula Get(string id)
        {
            Matricula? obj = dao_comentarios.ListarComentarios()
                                     .Find( m => m.codigo.Equals(id) );
            
            return obj;
        }

        // POST api/<MedicosAPIController>
        [HttpPost("PostComentario")]
        public string Post([FromBody] Matricula obj)
        {
            string mensaje = dao_comentarios.GrabarComentarios(obj);

            return mensaje;
        }

        

       

    }
}
