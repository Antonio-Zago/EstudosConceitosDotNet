namespace FactoryPattern.Notificadores
{
    public class PushNotificador : INotificador
    {
        private readonly string _chaveApi;

        public PushNotificador(string chaveApi)
        {
            _chaveApi = chaveApi;
        }

        public string Enviar(Notificacao notificacao)
        {
            var retorno = $"Push enviado (chave {_chaveApi}). Para {notificacao.Destinatario}. Mensagem: {notificacao.Mensagem}";

            return retorno;
        }
    }
}
