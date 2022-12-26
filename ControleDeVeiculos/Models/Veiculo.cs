using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ControleDeVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} do veículo é obrigatório")]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O {0} do veículo é obrigatório")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "O {0} do veículo é obrigatório")]
        public DateTime AnoFabricacao { get; set; }
        [Required]
        public string? Cor { get; set; }

        [Required(ErrorMessage = "A {0} do veículo é obrigatório")]
        public string? Placa { get; set; }
        public Marca? Marca { get; set; }
        public int MarcaId { get; set; }

        public Veiculo()
        {
        }

        public Veiculo(string nome, string modelo, DateTime anoFabricacao, string cor, Marca marca, string placa)
        {
            Nome = nome;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Cor = cor;
            Marca = marca;
            Placa = placa;
        }
    }
}
