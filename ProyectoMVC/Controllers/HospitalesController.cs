using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Repositories;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;
        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);

        }
        public IActionResult Details(int id)
        {   
            
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.CreateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital insertado";
            return View();
        }


        public IActionResult Update(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }
        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital modificado";
            return View(hospital);
        }
    }
}

