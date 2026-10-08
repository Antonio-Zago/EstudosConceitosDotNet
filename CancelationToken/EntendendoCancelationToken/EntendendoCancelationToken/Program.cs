var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("long-runing-request", async () =>
{
    var id = Guid.NewGuid();
    var results = new List<string>();

    for (int i = 0; i<100; i++)
    {
        await Task.Delay(1000);
        var result = $"{id} - Result {i}";
        Console.WriteLine(result);
        results.Add(result);
    }

    return Results.Ok(results);
});

app.MapGet("long-runing-request-com-cancelation", async (CancellationToken cancellationToken) =>
{
    var id = Guid.NewGuid();
    var results = new List<string>();

    for (int i = 0; i < 100; i++)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            //Passo o cancelationToken para lançar uma exceção caso o usuário cancele a requisição
            await Task.Delay(1000, cancellationToken);
            var result = $"{id} - Result {i}";
            Console.WriteLine(result);
            results.Add(result);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operação abortada");
        }

        
    }

    return Results.Ok(results);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
