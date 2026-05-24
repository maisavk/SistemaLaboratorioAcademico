# 11 - Application Results e DTOs

## Objetivo

Introduzir a camada de aplicação com envelopes de resultado e Data Transfer Objects (DTOs) para manter a lógica de aplicação separada das entidades de domínio. Isso permite que os serviços e controladores manipulem entradas e saídas de forma segura e desacoplada.

## Conceitos de POO Aplicados

- Separação de Responsabilidades: os envelopes `OperationResult` e `OperationResult<T>` encapsulam o resultado de operações de aplicação (sucesso/falha e mensagem), separando o comportamento de validação e transporte de dados da lógica de domínio.
- Desacoplamento através de DTOs: `CreateProgramaInput` e `ProgramaPrototipacaoDto` isolam a camada de apresentação da estrutura interna da aplicação, evitando expor entidades de domínio diretamente e simplificando a integração com interfaces e APIs.

## Código Gerado

### OperationResult

```csharp
namespace SistemaLaboratorioAcademico.Application.Results;

public class OperationResult
{
    public bool IsSuccess { get; init; }
    public string Message { get; init; }

    protected OperationResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static OperationResult Success(string message) => new(true, message);

    public static OperationResult Failure(string message) => new(false, message);
}

public class OperationResult<T> : OperationResult
{
    public T? Value { get; init; }

    private OperationResult(bool isSuccess, T? value, string message)
        : base(isSuccess, message)
    {
        Value = value;
    }

    public static OperationResult<T> Success(T value, string message) => new(true, value, message);

    public static new OperationResult<T> Failure(string message) => new(false, default, message);
}
```

### CreateProgramaInput

```csharp
namespace SistemaLaboratorioAcademico.Application.DTOs.ProgramaPrototipacao;

public sealed class CreateProgramaInput
{
    public string Nome { get; init; } = string.Empty;
    public int CoordenadorId { get; init; }
    public int OrientadorId { get; init; }
    public int LaboratorioId { get; init; }
}
```

### ProgramaPrototipacaoDto

```csharp
namespace SistemaLaboratorioAcademico.Application.DTOs.ProgramaPrototipacao;

public sealed class ProgramaPrototipacaoDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;

    public int CoordenadorId { get; init; }
    public string CoordenadorNome { get; init; } = string.Empty;

    public int OrientadorId { get; init; }
    public string OrientadorNome { get; init; } = string.Empty;

    public int LaboratorioId { get; init; }
    public string LaboratorioNome { get; init; } = string.Empty;
}
```
