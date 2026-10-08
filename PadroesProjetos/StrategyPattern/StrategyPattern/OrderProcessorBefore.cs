using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class OrderProcessorBefore
    {

        public string Process(string tipoPagamento, OrdemPagamento ordemPagamento) 
        { 
            switch(tipoPagamento)
            {
                case "CREDITO":
                    return ProcessarCredito(ordemPagamento);
                case "DEBITO":
                    return ProcessarDebito(ordemPagamento);
                case "CHEQUE":
                    return ProcessarCheque(ordemPagamento);
                default:
                    throw new Exception("Tipo de pagamento não identificado");
            }
        }

        private string ProcessarCredito(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cartão de crédito. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }

        private string ProcessarDebito(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cartão de débito. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }

        private string ProcessarCheque(OrdemPagamento ordemPagamento)
        {
            var retorno = $"Pagamento feito com cheque. Cliente {ordemPagamento.NomeCliente}. Valor {ordemPagamento.Valor}";

            return retorno;
        }
    }
}
