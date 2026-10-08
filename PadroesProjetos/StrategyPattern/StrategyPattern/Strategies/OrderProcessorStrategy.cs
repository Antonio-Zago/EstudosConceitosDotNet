namespace StrategyPattern.Strategies
{
    public class OrderProcessorStrategy
    {
        private readonly IReadOnlyDictionary<string, IPagamentoStrategy> _strategies;

        // O container injeta todas as estratégias registradas e o dicionário é montado aqui (chave = TipoPagamento)
        public OrderProcessorStrategy(IEnumerable<IPagamentoStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.TipoPagamento, StringComparer.OrdinalIgnoreCase);
        }

        // Substitui o switch: basta localizar a estratégia pela chave
        public string Process(string tipoPagamento, OrdemPagamento ordemPagamento)
        {
            if (!_strategies.TryGetValue(tipoPagamento, out var strategy))
                throw new Exception("Tipo de pagamento não identificado");

            return strategy.Processar(ordemPagamento);
        }

        // Percorre o dicionário e aciona cada uma das classes concretas
        public IEnumerable<string> ProcessarTodos(OrdemPagamento ordemPagamento)
        {
            foreach (var (tipoPagamento, strategy) in _strategies)
            {
                yield return $"[{tipoPagamento}] {strategy.Processar(ordemPagamento)}";
            }
        }
    }
}
