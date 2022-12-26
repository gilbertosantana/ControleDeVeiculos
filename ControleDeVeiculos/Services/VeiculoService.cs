using ControleDeVeiculos.Data;
using ControleDeVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVeiculos.Services
{
    public class VeiculoService
    {
        private readonly ControleDeVeiculosContext _context;

        public VeiculoService(ControleDeVeiculosContext context)
        {
            _context = context;
        }

        public List<Veiculo> FindAll()
        {
            return _context.Veiculo.ToList();
        }

        public Veiculo? FindById(int id)
        {
            return _context.Veiculo.Include(obj => obj.Marca).FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Veiculo veiculo)
        {
            veiculo.Placa = veiculo.Placa!.ToUpper();

            _context.Add(veiculo);
            _context.SaveChanges();
        }

        public void Update(Veiculo veiculo)
        {
            if(!_context.Veiculo.Any(x => x.Id == veiculo.Id))
            {
                throw new Exception();
            }

            _context.Update(veiculo);
            _context.SaveChanges();
            
        }

        public void Remove(int id)
        {
            var obj = _context.Veiculo.Find(id);
            _context.Veiculo.Remove(obj!);
            _context.SaveChanges();
        }
    }
}
