using ControleDeVeiculos.Data;
using ControleDeVeiculos.Models;
using ControleDeVeiculos.Services.Exceptions;
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

        public async Task<List<Veiculo>> FindAllAsync()
        {
            return await _context.Veiculo.ToListAsync();
        }

        public async Task<Veiculo?> FindByIdAsync(int id)
        {
            return await _context
                        .Veiculo
                        .Include(obj => obj.Marca)
                        .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Veiculo veiculo)
        {
            veiculo.Placa = veiculo.Placa!.ToUpper();

            _context.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Veiculo veiculo)
        {
            bool hasAny = await _context.Veiculo.AnyAsync(x => x.Id == veiculo.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(veiculo);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Veiculo.FindAsync(id);
            _context.Veiculo.Remove(obj!);
            await _context.SaveChangesAsync();
        }
    }
}
