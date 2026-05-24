namespace SistemaLaboratorioAcademico.Application.DTOs.ProgramaPrototipacao;

public sealed record CreateProgramaInput
{
    public string Nome { get; init; } = string.Empty;
    public int CoordenadorId { get; init; }
    public int OrientadorId { get; init; }
    public int LaboratorioId { get; init; }
}
