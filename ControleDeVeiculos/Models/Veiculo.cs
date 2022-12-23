using Microsoft.EntityFrameworkCore;

namespace ControleDeVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Modelo { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public string? Cor { get; set; }
        
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
