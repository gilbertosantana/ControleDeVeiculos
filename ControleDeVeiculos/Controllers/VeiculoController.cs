using ControleDeVeiculos.Models;
using ControleDeVeiculos.Models.ViewModels;
using ControleDeVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly VeiculoService _veiculoService;
        private readonly MarcaService _marcaService;

        public VeiculoController(VeiculoService veiculoService, MarcaService marcaService)
        {
            _veiculoService = veiculoService;
            _marcaService = marcaService;
        }
        public IActionResult Index()
        {
            var veiculos = _veiculoService.FindAll();
            return View(veiculos);
        }

        public IActionResult Create()
        {
            var marcas = _marcaService.FindAll();
            var viewModel = new VeiculoFormViewModel { Marcas = marcas };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Veiculo veiculo)
        {
            _veiculoService.Insert(veiculo);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _veiculoService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }
            List<Marca> marcas = _marcaService.FindAll();

            VeiculoFormViewModel viewModel = new VeiculoFormViewModel { Veiculo = obj, Marcas = marcas};

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
            {
                return NotFound();
            }
            _veiculoService.Update(veiculo);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _veiculoService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _veiculoService.Remove(id);
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _veiculoService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
