namespace FactoryPattern.Notificadores
{
    public class SmsNotificador : INotificador
    {
        private readonly int _limiteCaracteres;

        public SmsNotificador(int limiteCaracteres)
        {
            _limiteCaracteres = limiteCaracteres;
        }

        public string Enviar(Notificacao notificacao)
        {
            var mensagem = notificacao.Mensagem.Length > _limiteCaracteres
                ? notificacao.Mensagem[.._limiteCaracteres]
                : notificacao.Mensagem;

            var retorno = $"SMS enviado. Para {notificacao.Destinatario}. Mensagem: {mensagem}";

            return retorno;
        }
    }
}
