using System.Diagnostics;

namespace DecoratorPattern.Repositorios
{
    // Sem Decorator: log, cache e medição de tempo ficam misturados com a regra principal.
    // Para desligar o cache em um cenário, ligar só o log em outro, ou mudar a ordem dos comportamentos,
    // é preciso mexer nesta classe (ou criar subclasses para cada combinação: ComLog, ComCache, ComLogECache...).
    public class ProdutoRepositoryBefore
    {
        private readonly Dictionary<int, Produto> _bancoDeDados = new()
        {
            [1] = new Produto { Id = 1, Nome = "Teclado", Preco = 250m },
            [2] = new Produto { Id = 2, Nome = "Mouse", Preco = 120m },
        };
        private readonly Dictionary<int, Produto?> _cache = new();

        public Produto? ObterPorId(int id)
        {
            Console.WriteLine($"    [Log] Buscando produto {id}");
            var cronometro = Stopwatch.StartNew();

            if (!_cache.TryGetValue(id, out var produto))
            {
                Thread.Sleep(300);
                Console.WriteLine($"    [Banco] SELECT * FROM Produtos WHERE Id = {id}");
                produto = _bancoDeDados.GetValueOrDefault(id);
                _cache[id] = produto;
            }

            Console.WriteLine($"    [Tempo] {cronometro.ElapsedMilliseconds} ms");
            Console.WriteLine($"    [Log] Produto {id} {(produto is null ? "não encontrado" : "encontrado")}");

            return produto;
        }
    }
}
