# Tarefas API

API REST de tarefas desenvolvida com ASP.NET Core Minimal APIs e .NET 10.

## O que o projeto faz

A aplicação mantém uma lista de tarefas em memória e disponibiliza operações para:

- Listar todas as tarefas;
- Consultar uma tarefa pelo ID;
- Criar uma tarefa;
- Atualizar uma tarefa;
- Excluir uma tarefa;
- Visualizar e testar a API pelo Swagger.

Cada tarefa possui:

- `id`: identificador numérico;
- `titulo`: título da tarefa;
- `descricao`: descrição da tarefa;
- `concluida`: indica se a tarefa foi concluída;
- `dataCriacao`: data de criação em UTC.

## Requisitos

É necessário instalar:

1. **.NET SDK 10.0 ou superior**
2. **Git**, caso o projeto seja obtido pelo GitHub

O projeto usa os pacotes NuGet abaixo, que são restaurados automaticamente pelo .NET:

- `Microsoft.AspNetCore.OpenApi`
- `Swashbuckle.AspNetCore`

Não é necessário instalar esses pacotes manualmente.

Para verificar a instalação do .NET:

```powershell
dotnet --version
```

## Como baixar e executar

Clone o repositório:

```powershell
git clone https://github.com/erleson-sarmento-dev/tarefas-api.git
cd tarefas-api
```

Restaure as dependências:

```powershell
dotnet restore
```

Execute a aplicação:

```powershell
dotnet run
```

Por padrão, os endereços definidos pelo projeto são:

- HTTP: `http://localhost:5263`
- HTTPS: `https://localhost:7003`

O Swagger fica disponível em:

```text
http://localhost:5263/swagger
```

ou:

```text
https://localhost:7003/swagger
```

## Como testar os endpoints

### Listar tarefas

```http
GET http://localhost:5263/tarefas
```

### Consultar uma tarefa

```http
GET http://localhost:5263/tarefas/1
```

### Criar uma tarefa

```http
POST http://localhost:5263/tarefas
Content-Type: application/json

{
  "titulo": "Estudar ASP.NET Core",
  "descricao": "Criar uma API com Minimal APIs",
  "concluida": false
}
```

### Atualizar uma tarefa

```http
PUT http://localhost:5263/tarefas/1
Content-Type: application/json

{
  "titulo": "Estudar ASP.NET Core atualizado",
  "descricao": "Revisar os endpoints da API",
  "concluida": true
}
```

### Excluir uma tarefa

```http
DELETE http://localhost:5263/tarefas/1
```

Também é possível usar os exemplos do arquivo `TarefasApi.http` no Visual Studio Code ou no Visual Studio.

## Como acessar pela rede local

Por padrão, a aplicação pode ficar limitada ao computador local. Para permitir acesso por outros dispositivos na mesma rede, execute:

```powershell
dotnet run --urls "http://0.0.0.0:5263"
```

Descubra o endereço IP do computador que está executando a API:

```powershell
ipconfig
```

Em outro dispositivo conectado à mesma rede, acesse usando o IPv4 do computador servidor:

```text
http://IP_DO_COMPUTADOR:5263/swagger
```

Exemplo:

```text
http://192.168.0.25:5263/swagger
```

Se o Windows Firewall solicitar permissão, permita o `dotnet` ou crie uma regra de entrada para a porta TCP `5263`. O computador cliente também precisa conseguir alcançar o computador servidor na rede; redes públicas ou isolamento do Wi-Fi podem bloquear essa comunicação.

Para escutar em outra porta:

```powershell
dotnet run --urls "http://0.0.0.0:8080"
```

Nesse caso, o acesso será:

```text
http://IP_DO_COMPUTADOR:8080/swagger
```

## Observação sobre os dados

Este projeto usa uma lista em memória, sem banco de dados. Portanto:

- Os dados iniciais são recriados quando a aplicação inicia;
- Tarefas criadas ou alteradas são perdidas quando a aplicação é encerrada;
- Não é necessário instalar ou configurar um banco de dados.

## Compilação

Para apenas compilar o projeto:

```powershell
dotnet build
```

