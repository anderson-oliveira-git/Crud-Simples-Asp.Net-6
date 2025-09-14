
# API de Cadastro de Funcionários

API RESTful construída em **ASP.NET 6** para gerenciar funcionários, permitindo operações de **CRUD** (Create, Read, Update, Delete).

## Tecnologias

- ASP.NET 6
- C#
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

---

## Instalação

1. Clone o repositório:

```bash
https://github.com/anderson-oliveira-git/Crud-Simples-Asp.Net-6.git
```

2. Instale dependências:

```bash
dotnet restore
```

3. Configure a connection string no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EmployeeDB;Trusted_Connection=True;"
  }
}
```

4. Crie o banco de dados:

```bash
dotnet ef database update
```

5. Execute a API:

```bash
dotnet run
```

A API estará disponível em: `https://localhost:7055` ou `;http://localhost:5192`.

---

## Endpoints

### 1. Criar Funcionário

| Método | Endpoint           | Descrição                |
|--------|------------------|-------------------------|
| POST   | /api/v1/funcionario/cadastrar | Adiciona um novo funcionário |

---

### 2. Obter Funcionário por ID

| Método | Endpoint                  | Descrição                  |
|--------|--------------------------|---------------------------|
| GET    | /api/v1/funcionario/{id} | Retorna funcionário pelo ID |

---

### 3. Listar Todos os Funcionários

| Método | Endpoint           | Descrição               |
|--------|------------------|------------------------|
| GET    | /api/v1/funcionario/listar | Retorna todos os funcionários |

---

### 4. Atualizar Funcionário

| Método | Endpoint           | Descrição                  |
|--------|------------------|---------------------------|
| PUT    | /api/v1/funcionario/atualizar | Atualiza um funcionário existente |


---

### 5. Excluir Funcionário

| Método | Endpoint                  | Descrição                    |
|--------|--------------------------|-----------------------------|
| DELETE | /api/v1/funcionario/deletar | Remove um funcionário pelo ID |

---

## Model `Funcionario`

```csharp

using System.ComponentModel.DataAnnotations;
using WebApiBase.Enums;

namespace WebApiBase.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public bool Ativo { get; set; }

    public TurnoEnum Turno { get; set; }
    public DepartamentoEnum Departamento { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime DataAtualizacao { get; set; } = DateTime.Now.ToLocalTime();
}
```

---

## Observações

- Use **Swagger** (`/swagger`) para testar os endpoints de forma interativa.
- Todos os endpoints retornam um objeto padrão com:
  - `success` (bool)
  - `message` (string) quando aplicável
  - `data` (objeto ou lista de objetos)
