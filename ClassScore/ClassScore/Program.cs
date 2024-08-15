var builder = WebApplication.CreateBuilder(args);

// Configura��o dos Servi�os
ConfigureServices(builder.Services);

// Constru��o da Aplica��o
var app = builder.Build();

// Configura��o do Pipeline
ConfigurePipeline(app);

// Inicializa��o da Aplica��o
app.Run();

// M�todo para configurar os servi�os
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

// M�todo para configurar o pipeline de requisi��es HTTP
void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

