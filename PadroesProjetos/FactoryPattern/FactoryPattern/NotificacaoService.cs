using FactoryPattern.Factories;

namespace FactoryPattern
{
    // Com Factory: o serviço não usa "new" em nenhuma classe concreta; ele delega a criação à fábrica
    // e trabalha apenas com a interface INotificador
    public class NotificacaoService
    {
        private readonly INotificadorFactory _factory;

        public NotificacaoService(INotificadorFactory factory)
        {
            _factory = factory;
        }

        public string Enviar(string canal, Notificacao notificacao)
        {
            var notificador = _factory.Criar(canal);

            return notificador.Enviar(notificacao);
        }
    }
}
