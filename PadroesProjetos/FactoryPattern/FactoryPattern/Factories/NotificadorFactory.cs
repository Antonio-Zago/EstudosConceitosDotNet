using FactoryPattern.Notificadores;

namespace FactoryPattern.Factories
{
    // Único lugar do sistema que conhece as classes concretas e sabe como construí-las
    public class NotificadorFactory : INotificadorFactory
    {
        public INotificador Criar(string canal)
        {
            return canal.ToUpperInvariant() switch
            {
                "EMAIL" => new EmailNotificador("smtp.empresa.com", 587),
                "SMS" => new SmsNotificador(limiteCaracteres: 160),
                "PUSH" => new PushNotificador("chave-api-push"),
                _ => throw new Exception("Canal de notificação não identificado")
            };
        }
    }
}
