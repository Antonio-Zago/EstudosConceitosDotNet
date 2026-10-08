namespace StrategyPattern.Strategies
{
    public class PagamentoCreditoStrategy : IPagamentoStrategy
    {
        public string TipoPagamento => "CREDITO";

        public string Processar(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cartão de crédito. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }
    }
}
