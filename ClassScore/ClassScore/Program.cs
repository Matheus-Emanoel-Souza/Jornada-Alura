var builder = WebApplication.CreateBuilder(args);

// Configuração dos Serviços
ConfigureServices(builder.Services);

// Construção da Aplicação
var app = builder.Build();

// Configuração do Pipeline
ConfigurePipeline(app);

// Inicialização da Aplicação
app.Run();

// Método para configurar os serviços
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

// Método para configurar o pipeline de requisições HTTP
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

