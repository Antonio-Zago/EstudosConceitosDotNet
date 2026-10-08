namespace StrategyPattern.Strategies
{
    public class PagamentoDebitoStrategy : IPagamentoStrategy
    {
        public string TipoPagamento => "DEBITO";

        public string Processar(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cartão de débito. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }
    }
}
