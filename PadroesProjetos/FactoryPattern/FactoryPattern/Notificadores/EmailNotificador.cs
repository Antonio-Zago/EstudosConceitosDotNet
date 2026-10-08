namespace FactoryPattern.Notificadores
{
    public class EmailNotificador : INotificador
    {
        private readonly string _servidorSmtp;
        private readonly int _porta;

        public EmailNotificador(string servidorSmtp, int porta)
        {
            _servidorSmtp = servidorSmtp;
            _porta = porta;
        }

        public string Enviar(Notificacao notificacao)
        {
            var retorno = $"E-mail enviado via {_servidorSmtp}:{_porta}. Para {notificacao.Destinatario}. Mensagem: {notificacao.Mensagem}";

            return retorno;
        }
    }
}
