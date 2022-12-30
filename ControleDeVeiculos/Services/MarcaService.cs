using ControleDeVeiculos.Data;
using ControleDeVeiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVeiculos.Services
{
    public class MarcaService
    {
        private readonly ControleDeVeiculosContext _context;

        public MarcaService(ControleDeVeiculosContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> FindAllAsync()
        {
            return await _context.Marca.OrderBy(marca => marca.Name).ToListAsync();
        }
    }
}
