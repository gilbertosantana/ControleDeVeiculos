using ControleDeVeiculos.Data;
using ControleDeVeiculos.Models;

namespace ControleDeVeiculos.Services
{
    public class MarcaService
    {
        private readonly ControleDeVeiculosContext _context;

        public MarcaService(ControleDeVeiculosContext context)
        {
            _context = context;
        }

        public List<Marca> FindAll()
        {
            return _context.Marca.OrderBy(marca => marca.Name).ToList();
        }
    }
}
