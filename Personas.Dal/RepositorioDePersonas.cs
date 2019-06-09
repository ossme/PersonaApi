using Personas.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Dal
{
    public class RepositorioDePersonas
    {
        private static List<PersonaDto> personas;
        private List<PersonaDto> ListadoInicial()
        {
            if (personas == null)
            {

                personas = new List<PersonaDto>()
                {
                    new PersonaDto { id = 1, nombre = "Haleemah", apellido = "Redfern"},
                    new PersonaDto { id = 2, nombre = "Aya", apellido = "Bostock"},
                    new PersonaDto { id = 3, nombre = "Sohail", apellido = "Perez"},
                    new PersonaDto { id = 4, nombre = "Merryn", apellido = "Peck"},
                    new PersonaDto { id = 5, nombre = "Cairon", apellido = "Reynolds"}
                };
            }
            return personas;
        }

        public RepositorioDePersonas()
        {
            personas = ListadoInicial();
        }

        public List<PersonaDto> ObtenerListadoDePersonas()
        {
            return personas;
        }

        public void AgregarPersona(PersonaDto request)
        {
            personas.Add(request);
        }

        public bool EliminarPersona(int id)
        {
            PersonaDto persona = (personas.FirstOrDefault(x => x.id == id));
            if (persona == null)
                return false;

            personas.Remove(persona);
            return true;
        }
    }
}
