using DecoratorPattern.Repositorios;

namespace DecoratorPattern.Decorators
{
    // Decorator base: implementa a MESMA interface e guarda uma referência para outro IProdutoRepository.
    // Por padrão só repassa a chamada; as subclasses acrescentam comportamento antes e/ou depois dela.
    public abstract class ProdutoRepositoryDecorator : IProdutoRepository
    {
        protected readonly IProdutoRepository _interno;

        protected ProdutoRepositoryDecorator(IProdutoRepository interno)
        {
            _interno = interno;
        }

        public virtual Produto? ObterPorId(int id) => _interno.ObterPorId(id);
    }
}
