using FactoryPattern.Notificadores;

namespace FactoryPattern.Factories
{
    // Contrato da fábrica: quem consome só sabe pedir "me dê um notificador para este canal"
    public interface INotificadorFactory
    {
        INotificador Criar(string canal);
    }
}
