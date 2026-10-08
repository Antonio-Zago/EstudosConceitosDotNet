namespace FactoryPattern.Notificadores
{
    // Produto: contrato comum de tudo que a fábrica é capaz de criar
    public interface INotificador
    {
        string Enviar(Notificacao notificacao);
    }
}
