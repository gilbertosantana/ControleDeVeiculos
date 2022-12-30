using ControleDeVeiculos.Models;
using ControleDeVeiculos.Models.ViewModels;
using ControleDeVeiculos.Services.Exceptions;
using ControleDeVeiculos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoService.FindAllAsync();
            return View(veiculos);
        }

        public async Task<IActionResult> Create()
        {
            var marcas = await _marcaService.FindAllAsync();
            var viewModel = new VeiculoFormViewModel { Marcas = marcas };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                var marcas = await _marcaService.FindAllAsync();
                var viewModel = new VeiculoFormViewModel { Veiculo = veiculo, Marcas = marcas };
                return View(viewModel);
            }
            await _veiculoService.InsertAsync(veiculo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _veiculoService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }
            List<Marca> marcas = await _marcaService.FindAllAsync();

            VeiculoFormViewModel viewModel = new VeiculoFormViewModel { Veiculo = obj, Marcas = marcas };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                var marcas = await _marcaService.FindAllAsync();
                var viewModel = new VeiculoFormViewModel { Veiculo = veiculo, Marcas = marcas };
                return View(viewModel);
            }
            if (id != veiculo.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not mismatch" });
            }
            try
            {
                await _veiculoService.UpdateAsync(veiculo);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
            catch(DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }
            var obj = await _veiculoService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _veiculoService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _veiculoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
