using SistemaLaboratorioAcademico.Domain.Entities;

namespace SistemaLaboratorioAcademico.Infrastructure.Persistence;

public sealed class InMemoryLaboratoryStore
{
    private readonly List<Estudante> _estudantes = new();
    private readonly List<Professor> _professores = new();
    private readonly List<LaboratorioMaker> _laboratorios = new();
    private readonly List<ProgramaPrototipacao> _programas = new();
    private readonly List<Especialista> _especialistas = new();

    public IReadOnlyList<Estudante> Estudantes => _estudantes;
    public IReadOnlyList<Professor> Professores => _professores;
    public IReadOnlyList<LaboratorioMaker> Laboratorios => _laboratorios;
    public IReadOnlyList<ProgramaPrototipacao> Programas => _programas;
    public IReadOnlyList<Especialista> Especialistas => _especialistas;

    public void AddEstudante(Estudante estudante)
    {
        ArgumentNullException.ThrowIfNull(estudante);
        _estudantes.Add(estudante);
    }

    public void AddProfessor(Professor professor)
    {
        ArgumentNullException.ThrowIfNull(professor);
        _professores.Add(professor);
    }

    public void AddLaboratorio(LaboratorioMaker laboratorio)
    {
        ArgumentNullException.ThrowIfNull(laboratorio);
        _laboratorios.Add(laboratorio);
    }

    public void AddPrograma(ProgramaPrototipacao programa)
    {
        ArgumentNullException.ThrowIfNull(programa);
        _programas.Add(programa);
    }

    public void AddEspecialista(Especialista especialista)
    {
        ArgumentNullException.ThrowIfNull(especialista);
        _especialistas.Add(especialista);
    }
}
