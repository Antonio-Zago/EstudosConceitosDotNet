using FactoryPattern;
using FactoryPattern.Factories;

var notificacao = new Notificacao { Destinatario = "Antonio", Mensagem = "Seu pedido foi aprovado!" };
string[] canais = ["EMAIL", "SMS", "PUSH", "WHATSAPP"];

Console.WriteLine("===== Forma anterior (switch + new no serviço) =====");
var serviceBefore = new NotificacaoServiceBefore();
foreach (var canal in canais)
{
    try
    {
        Console.WriteLine(serviceBefore.Enviar(canal, notificacao));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{canal}: {ex.Message}");
    }
}

Console.WriteLine();
Console.WriteLine("===== Factory Pattern =====");
// A fábrica é entregue ao serviço pelo construtor; o serviço depende só da interface
var service = new NotificacaoService(new NotificadorFactory());
foreach (var canal in canais)
{
    try
    {
        Console.WriteLine(service.Enviar(canal, notificacao));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{canal}: {ex.Message}");
    }
}
