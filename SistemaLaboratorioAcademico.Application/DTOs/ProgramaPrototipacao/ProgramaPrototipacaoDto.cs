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
