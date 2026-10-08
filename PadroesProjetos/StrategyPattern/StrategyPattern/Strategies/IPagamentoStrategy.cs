namespace StrategyPattern.Strategies
{
    // Contrato comum a todas as estratégias de pagamento
    public interface IPagamentoStrategy
    {
        // Chave usada para localizar a estratégia no dicionário
        string TipoPagamento { get; }

        string Processar(OrdemPagamento ordemPagamento);
    }
}
