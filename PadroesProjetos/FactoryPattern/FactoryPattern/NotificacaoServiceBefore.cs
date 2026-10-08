using FactoryPattern.Notificadores;

namespace FactoryPattern
{
    // Sem Factory: o próprio serviço decide QUAL classe concreta instanciar (new) e como configurá-la.
    // Todo lugar do sistema que precisar de um notificador vai repetir este switch.
    public class NotificacaoServiceBefore
    {
        public string Enviar(string canal, Notificacao notificacao)
        {
            switch (canal)
            {
                case "EMAIL":
                    var email = new EmailNotificador("smtp.empresa.com", 587);
                    return email.Enviar(notificacao);
                case "SMS":
                    var sms = new SmsNotificador(limiteCaracteres: 160);
                    return sms.Enviar(notificacao);
                case "PUSH":
                    var push = new PushNotificador("chave-api-push");
                    return push.Enviar(notificacao);
                default:
                    throw new Exception("Canal de notificação não identificado");
            }
        }
    }
}
