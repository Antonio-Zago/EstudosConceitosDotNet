namespace StrategyPattern.Strategies
{
    public class PagamentoChequeStrategy : IPagamentoStrategy
    {
        public string TipoPagamento => "CHEQUE";

        public string Processar(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cheque. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }
    }
}
