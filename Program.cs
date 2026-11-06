using TarefasApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Configurar o pipeline HTTP (Swagger em ambiente de desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. Base de dados em memória (Lista)
var tarefas = new List<Tarefa>
{
    new() { Id = 1, Titulo = "Instalar o .NET SDK", Concluida = true },
    new() { Id = 2, Titulo = "Criar o projeto Web API", Concluida = true },
    new() { Id = 3, Titulo = "Testar endpoints no Swagger", Concluida = false }
};

// 4. Endpoints da API

// GET: Obter todas as tarefas
app.MapGet("/tarefas", () => Results.Ok(tarefas))
   .WithTags("Tarefas")
   .WithSummary("Lista todas as tarefas");

// GET: Obter tarefa por ID
app.MapGet("/tarefas/{id:int}", (int id) =>
{
    var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
    return tarefa is not null ? Results.Ok(tarefa) : Results.NotFound("Tarefa não encontrada.");
})
.WithTags("Tarefas")
.WithSummary("Obtém uma tarefa específica pelo ID");

// POST: Criar uma nova tarefa
app.MapPost("/tarefas", (Tarefa novaTarefa) =>
{
    novaTarefa.Id = tarefas.Count != 0 ? tarefas.Max(t => t.Id) + 1 : 1;
    tarefas.Add(novaTarefa);
    return Results.Created($"/tarefas/{novaTarefa.Id}", novaTarefa);
})
.WithTags("Tarefas")
.WithSummary("Cria uma nova tarefa");

// PUT: Atualizar uma tarefa existente
app.MapPut("/tarefas/{id:int}", (int id, Tarefa dadosAtualizados) =>
{
    var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null) return Results.NotFound("Tarefa não encontrada.");

    tarefa.Titulo = dadosAtualizados.Titulo;
    tarefa.Descricao = dadosAtualizados.Descricao;
    tarefa.Concluida = dadosAtualizados.Concluida;

    return Results.Ok(tarefa);
})
.WithTags("Tarefas")
.WithSummary("Atualiza os dados de uma tarefa existente");

// DELETE: Remover uma tarefa
app.MapDelete("/tarefas/{id:int}", (int id) =>
{
    var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null) return Results.NotFound("Tarefa não encontrada.");

    tarefas.Remove(tarefa);
    return Results.NoContent();
})
.WithTags("Tarefas")
.WithSummary("Remove uma tarefa pelo ID");

// 5. Iniciar a aplicação
app.Run();
