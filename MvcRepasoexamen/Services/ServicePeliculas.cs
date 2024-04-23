using MvcRepasoexamen.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcRepasoexamen.Services
{
    public class ServicePeliculas
    {
        //CLASE PARA INDICAR EL FORMATO QUE ESTAMOS  
        //CONSUMIENDO 
        private MediaTypeWithQualityHeaderValue header;
        private string ApiUrl;

        public ServicePeliculas()
        {
            this.ApiUrl = "https://localhost:7087/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Pelicula>> GetPeliculasAsync()
        {
            string request = "api/peliculas/getpeliculas";
            List<Pelicula> data = await this.CallApiAsync<List<Pelicula>>(request);
            return data;
        }
        public async Task<Pelicula> FindPeliculaAsync(int idPelicula)
        {
            string request = "api/peliculas/getpelicula/" + idPelicula;
            Pelicula data = await this.CallApiAsync<Pelicula>(request);
            return data;
        }

        public async Task DeletePeliculaAsync(int idPelicula)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/peliculas/deletepelicula/" + idPelicula;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();

                //NO ENVIAMOS NADA PORQUE NO RECIBE NADA NI DEVUELVE 
                //NADA 
                HttpResponseMessage response = await client.DeleteAsync(request);
                //PODRIAMOS DEVOLVER QUE ES LO QUE HA SUCEDIDO 
                //POR EJEMPLO, DEVOLVIENDO STATUS CODE 
                //return response.StatusCode; 
            }
        }
        public async Task InsertPeliculaAsync(Pelicula peli)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/peliculas/createpelicula";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //INSTANCIAMOS NUESTRO MODEL              
                //CONVERTIMOS NUESTRO MODEL A JSON 
                string json = JsonConvert.SerializeObject(peli);
                //PARA ENVIAR DATOS (data) AL SERVICIO DEBEMOS  
                //UTILIZAR LA CLASE StringContent QUE NOS PEDIRA 
                //LOS DATOS, SU ENCODING Y EL TIPO DE FORMATO 
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
            }
        }
        public async Task UpdatePeliculaAsync(Pelicula peli)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/peliculas/editpelicula";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);              
                string json = JsonConvert.SerializeObject(peli);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
            }
        }
        public async Task<List<Genero>> GetGenerosAsync()
        {
            string request = "api/peliculas/getgeneros";
            List<Genero> data = await this.CallApiAsync<List<Genero>>(request);
            return data;
        }
        public async Task<Genero> FindGeneroAsync(int idGenero)
        {
            string request = "api/peliculas/getgenero/" + idGenero;
            Genero data = await this.CallApiAsync<Genero>(request);
            return data;
        }
        public async Task<List<Pelicula>> GetPeliculasGeneroAsync(int idPelicula)
        {
            string request = "api/peliculas/getpeliculasgenero/" + idPelicula;
            List<Pelicula> data = await this.CallApiAsync<List<Pelicula>>(request);
            return data;
        }


    }
}
