# 13 - Application Service para Programa de Prototipação

## Objetivo

Explicar a introdução do serviço de aplicação para orquestrar o fluxo de criação de um `ProgramaPrototipacao`.

Essa camada é responsável por:
- receber o comando de criação em formato de DTO (`CreateProgramaInput`);
- buscar os atores necessários no `InMemoryLaboratoryStore`;
- validar a existência do estudante coordenador, professor orientador e laboratório maker;
- criar a entidade de domínio e persistir no store;
- retornar um envelope de resultado consistente usando `OperationResult<ProgramaPrototipacaoDto>`.

## Conceitos de POO Aplicados

- Orquestração de Fluxo
  - O service centraliza o fluxo de criação, desligando a lógica de busca e validação de quem chama o serviço.
  - Ao consultar o `InMemoryLaboratoryStore`, ele mantém a sequência correta: estudante, professor e laboratório antes da criação.

- Desacoplamento da Camada de Apresentação
  - O service trabalha com DTOs de entrada e saída (`CreateProgramaInput` e `ProgramaPrototipacaoDto`), isolando a camada de apresentação da entidade de domínio.
  - A camada de apresentação não precisa conhecer a forma interna de `ProgramaPrototipacao`, apenas o contrato de entrada e saída.

- Envelope de Resultado
  - O uso de `OperationResult<T>` permite comunicar sucesso ou falha sem lançar exceções para condições de validação comuns.
  - Isso deixa o contrato do serviço mais previsível e claro para clientes, em vez de depender de exceções para controle de fluxo.

- Tratamento de Falhas
  - A validação da existência dos atores resulta em mensagens específicas de falha.
  - Exceções inesperadas são capturadas e convertidas em `OperationResult<ProgramaPrototipacaoDto>.Failure(...)`, o que torna o serviço resiliente.

## Código Gerado

```csharp
using System;
using System.Linq;
using SistemaLaboratorioAcademico;
using SistemaLaboratorioAcademico.Application.DTOs.ProgramaPrototipacao;
using SistemaLaboratorioAcademico.Application.Results;

namespace SistemaLaboratorioAcademico.Application.Services;

public sealed class ProgramaPrototipacaoService
{
    private readonly InMemoryLaboratoryStore _store;

    public ProgramaPrototipacaoService(InMemoryLaboratoryStore store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
    }

    public OperationResult<ProgramaPrototipacaoDto> Create(CreateProgramaInput input)
    {
        try
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var estudante = _store.Estudantes.FirstOrDefault(x => x.Id == input.CoordenadorId);
            if (estudante is null)
            {
                return OperationResult<ProgramaPrototipacaoDto>.Failure("O estudante coordenador informado não foi encontrado.");
            }

            var professor = _store.Professores.FirstOrDefault(x => x.Id == input.OrientadorId);
            if (professor is null)
            {
                return OperationResult<ProgramaPrototipacaoDto>.Failure("O professor orientador informado não foi encontrado.");
            }

            var laboratorio = _store.Laboratorios.FirstOrDefault(x => x.Id == input.LaboratorioId);
            if (laboratorio is null)
            {
                return OperationResult<ProgramaPrototipacaoDto>.Failure("O laboratório Maker informado não foi encontrado.");
            }

            var programa = new ProgramaPrototipacao(input.Nome, estudante, professor, laboratorio);
            _store.AddPrograma(programa);

            return OperationResult<ProgramaPrototipacaoDto>.Success(ToDto(programa), "Programa de prototipação criado com sucesso.");
        }
        catch (Exception exception)
        {
            return OperationResult<ProgramaPrototipacaoDto>.Failure($"Falha ao criar programa: {exception.Message}");
        }
    }

    private static ProgramaPrototipacaoDto ToDto(ProgramaPrototipacao programa)
        => new()
        {
            Id = programa.Id,
            Nome = programa.Nome,
            CoordenadorId = programa.Coordenador.Id,
            CoordenadorNome = programa.Coordenador.Nome,
            OrientadorId = programa.Orientador.Id,
            OrientadorNome = programa.Orientador.Nome,
            LaboratorioId = programa.Laboratorio.Id,
            LaboratorioNome = programa.Laboratorio.Nome
        };
}
```