using System.Diagnostics;
using DecoratorPattern.Repositorios;

namespace DecoratorPattern.Decorators
{
    public class TempoProdutoRepository : ProdutoRepositoryDecorator
    {
        public TempoProdutoRepository(IProdutoRepository interno) : base(interno) { }

        public override Produto? ObterPorId(int id)
        {
            var cronometro = Stopwatch.StartNew();

            var produto = base.ObterPorId(id);

            Console.WriteLine($"    [Tempo] {cronometro.ElapsedMilliseconds} ms");
            return produto;
        }
    }
}
