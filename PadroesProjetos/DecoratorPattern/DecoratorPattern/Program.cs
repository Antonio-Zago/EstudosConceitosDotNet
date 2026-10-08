using System.Globalization;
using DecoratorPattern;
using DecoratorPattern.Decorators;
using DecoratorPattern.Repositorios;

CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
int[] ids = [1, 1, 3];

Console.WriteLine("===== Forma anterior (tudo misturado em uma classe) =====");
var repositoryBefore = new ProdutoRepositoryBefore();
foreach (var id in ids)
{
    var produto = repositoryBefore.ObterPorId(id);
    Console.WriteLine(produto is null ? $"Produto {id} não existe" : $"{produto.Nome} - {produto.Preco:C}");
}

Console.WriteLine();
Console.WriteLine("===== Decorator: repositório puro =====");
Executar(new ProdutoService(new ProdutoRepository()));

Console.WriteLine();
Console.WriteLine("===== Decorator: Log -> Tempo -> Cache -> Repositório =====");
// Cada decorator embrulha o anterior; a chamada entra pelo de fora e vai "descascando" até o repositório real
IProdutoRepository decorado =
    new LogProdutoRepository(
        new TempoProdutoRepository(
            new CacheProdutoRepository(
                new ProdutoRepository())));
Executar(new ProdutoService(decorado));

Console.WriteLine();
Console.WriteLine("===== Decorator: ordem trocada (Cache -> Tempo -> Repositório) =====");
// Com o cache por fora, um HIT nem chega ao decorator de tempo: a ordem dos decorators muda o comportamento
Executar(new ProdutoService(
    new CacheProdutoRepository(
        new TempoProdutoRepository(
            new ProdutoRepository()))));

void Executar(ProdutoService service)
{
    foreach (var id in ids)
        Console.WriteLine(service.Exibir(id));
}
