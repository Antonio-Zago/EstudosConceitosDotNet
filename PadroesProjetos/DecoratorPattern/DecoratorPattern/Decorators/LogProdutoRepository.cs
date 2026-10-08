using DecoratorPattern.Repositorios;

namespace DecoratorPattern.Decorators
{
    public class LogProdutoRepository : ProdutoRepositoryDecorator
    {
        public LogProdutoRepository(IProdutoRepository interno) : base(interno) { }

        public override Produto? ObterPorId(int id)
        {
            Console.WriteLine($"    [Log] Buscando produto {id}");

            var produto = base.ObterPorId(id);

            Console.WriteLine($"    [Log] Produto {id} {(produto is null ? "não encontrado" : "encontrado")}");
            return produto;
        }
    }
}
