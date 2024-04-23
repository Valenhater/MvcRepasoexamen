using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRepasoexamen.Models
{
    public class Genero
    {
        //ESTO SOLAMENTE LO INCLUIREMOS SI LAS PROPIEDADES  
        //SE LLAMAN DIFERENTE AL JSON 
        //[JsonProperty("idHospital")]
        public int IdGenero { get; set; }
        public string Nombre { get; set; }
    }
}
