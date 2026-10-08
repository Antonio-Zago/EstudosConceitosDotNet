using DecoratorPattern.Repositorios;

namespace DecoratorPattern.Decorators
{
    // Este decorator pode decidir NÃO chamar o objeto interno: se o produto está no cache, a chamada para aqui
    public class CacheProdutoRepository : ProdutoRepositoryDecorator
    {
        private readonly Dictionary<int, Produto?> _cache = new();

        public CacheProdutoRepository(IProdutoRepository interno) : base(interno) { }

        public override Produto? ObterPorId(int id)
        {
            if (_cache.TryGetValue(id, out var produto))
            {
                Console.WriteLine($"    [Cache] HIT produto {id}");
                return produto;
            }

            Console.WriteLine($"    [Cache] MISS produto {id}");
            produto = base.ObterPorId(id);
            _cache[id] = produto;

            return produto;
        }
    }
}
