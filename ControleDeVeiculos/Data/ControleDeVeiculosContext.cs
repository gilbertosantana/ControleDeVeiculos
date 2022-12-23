using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeVeiculos.Models;

namespace ControleDeVeiculos.Data
{
    public class ControleDeVeiculosContext : DbContext
    {
        public ControleDeVeiculosContext (DbContextOptions<ControleDeVeiculosContext> options)
            : base(options)
        {
        }

        public DbSet<Marca> Marca { get; set; } = default!;
        public DbSet<Veiculo> Veiculo { get; set; } = default!;
    }
}
