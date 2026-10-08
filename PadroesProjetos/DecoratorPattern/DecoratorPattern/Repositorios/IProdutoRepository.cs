namespace DecoratorPattern.Repositorios
{
    // Componente: contrato comum entre o objeto real e todos os decorators.
    // Quem consome só conhece esta interface, então não sabe (nem precisa saber) se está falando
    // com o repositório real ou com um decorator que o embrulha.
    public interface IProdutoRepository
    {
        Produto? ObterPorId(int id);
    }
}
