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
