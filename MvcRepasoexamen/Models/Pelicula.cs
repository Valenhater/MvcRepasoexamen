using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRepasoexamen.Models
{
    public class Pelicula
    {
        //ESTO SOLAMENTE LO INCLUIREMOS SI LAS PROPIEDADES  
        //SE LLAMAN DIFERENTE AL JSON 
        //[JsonProperty("idHospital")]
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Director { get; set; }
        public string Imagen { get; set; }
        public string Sinopsis { get; set; }
        public int Precio { get; set; }
        public int IdGenero { get; set; }
    }
}
