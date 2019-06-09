using Personas.Dal;
using Personas.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PersonasApi.Controllers
{
    [Route("api/v1/personas")]
    public class PersonaController : ApiController
    {

        

        [HttpGet]
        public HttpResponseMessage ObtenerTodos()
        {
            try
            {
                RepositorioDePersonas repo = new RepositorioDePersonas();
                var listado = repo.ObtenerListadoDePersonas();
                return Request.CreateResponse<List<PersonaDto>>(HttpStatusCode.OK, listado);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Agregar(PersonaDto request)
        {
            try
            {
                if (request == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                RepositorioDePersonas repo = new RepositorioDePersonas();
                repo.AgregarPersona(request);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete, System.Web.Http.Route("api/v1/personas/{id}")]
        public async Task<HttpResponseMessage> Eliminar(int id)
        {
            try
            {
                RepositorioDePersonas repo = new RepositorioDePersonas();
                if (!repo.EliminarPersona(id))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        

    }
}
