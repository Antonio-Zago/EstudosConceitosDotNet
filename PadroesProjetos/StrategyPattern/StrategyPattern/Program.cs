using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StrategyPattern;
using StrategyPattern.Strategies;

var builder = Host.CreateApplicationBuilder();

// Cada classe concreta é registrada pela interface
builder.Services.AddSingleton<IPagamentoStrategy, PagamentoCreditoStrategy>();
builder.Services.AddSingleton<IPagamentoStrategy, PagamentoDebitoStrategy>();
builder.Services.AddSingleton<IPagamentoStrategy, PagamentoChequeStrategy>();

// O processador também é registrado, para o container injetar as estratégias no construtor
builder.Services.AddSingleton<OrderProcessorStrategy>();

var app = builder.Build();

var ordemPagamento = new OrdemPagamento { NomeCliente = "Antonio", Valor = 150.75m };
string[] tiposPagamento = ["CREDITO", "DEBITO", "CHEQUE", "PIX"];

Console.WriteLine("===== Forma anterior (switch) =====");
var processorBefore = new OrderProcessorBefore();
foreach (var tipo in tiposPagamento)
{
    try
    {
        Console.WriteLine(processorBefore.Process(tipo, ordemPagamento));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{tipo}: {ex.Message}");
    }
}

Console.WriteLine();
Console.WriteLine("===== Strategy Pattern (busca pela chave) =====");
// Único ponto em que pedimos algo ao container; as estratégias são injetadas automaticamente
var processorStrategy = app.Services.GetRequiredService<OrderProcessorStrategy>();
foreach (var tipo in tiposPagamento)
{
    try
    {
        Console.WriteLine(processorStrategy.Process(tipo, ordemPagamento));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{tipo}: {ex.Message}");
    }
}

Console.WriteLine();
Console.WriteLine("===== Strategy Pattern (percorrendo o dicionário) =====");
foreach (var resultado in processorStrategy.ProcessarTodos(ordemPagamento))
{
    Console.WriteLine(resultado);
}
