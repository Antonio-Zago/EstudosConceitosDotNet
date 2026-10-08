using DecoratorPattern.Repositorios;

namespace DecoratorPattern
{
    // O serviço depende só da interface: recebe o repositório "puro" ou "decorado" sem nenhuma mudança no código
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public string Exibir(int id)
        {
            var produto = _repository.ObterPorId(id);

            return produto is null ? $"Produto {id} não existe" : $"{produto.Nome} - {produto.Preco:C}";
        }
    }
}
