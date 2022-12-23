namespace ControleDeVeiculos.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        
        public Marca()
        {

        }
        public Marca(string name)
        {
            Name = name;
        }

        public void AddVeiculos(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void RemoveVeiculo(Veiculo veiculo)
        {
            Veiculos.Remove(veiculo);
        }
    }
}
