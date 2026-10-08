namespace DecoratorPattern.Repositorios
{
    // Componente concreto: faz apenas o trabalho principal (buscar o produto), sem log, cache ou medição de tempo
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Dictionary<int, Produto> _bancoDeDados = new()
        {
            [1] = new Produto { Id = 1, Nome = "Teclado", Preco = 250m },
            [2] = new Produto { Id = 2, Nome = "Mouse", Preco = 120m },
        };

        public Produto? ObterPorId(int id)
        {
            // Simula a latência de uma consulta ao banco
            Thread.Sleep(300);
            Console.WriteLine($"    [Banco] SELECT * FROM Produtos WHERE Id = {id}");

            return _bancoDeDados.GetValueOrDefault(id);
        }
    }
}
