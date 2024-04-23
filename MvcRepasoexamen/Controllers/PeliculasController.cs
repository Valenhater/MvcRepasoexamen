using MvcRepasoexamen.Models;
using Microsoft.AspNetCore.Mvc;
using MvcRepasoexamen.Services;

namespace MvcRepasoexamen.Controllers
{
    public class PeliculasController : Controller
    {
        private ServicePeliculas service;

        public PeliculasController(ServicePeliculas service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Pelicula> peliculas = await this.service.GetPeliculasAsync();
            return View(peliculas);
        }
        public async Task<IActionResult> Details(int id)
        {
            Pelicula pelicula = await this.service.FindPeliculaAsync(id);
            return View(pelicula);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePeliculaAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pelicula peli)
        {
            await this.service.InsertPeliculaAsync(peli);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            Pelicula peli = await this.service.FindPeliculaAsync(id);
            return View(peli);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Pelicula peli)
        {
            await this.service.UpdatePeliculaAsync(peli);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PeliculasGenero()
        {
            ViewData["GENEROS"] = await this.service.GetGenerosAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PeliculasGenero(int id)
        {
            List<Pelicula> peliculas = await this.service.GetPeliculasGeneroAsync(id);
            ViewData["GENEROS"] = await this.service.GetGenerosAsync();
            return View(peliculas);
        }

    }
}
