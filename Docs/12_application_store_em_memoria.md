# 12_application_store_em_memoria

## Objetivo

O `InMemoryLaboratoryStore` serve como a central de persistência em memória da camada Application. Ele simula um banco de dados simples dentro da aplicação, reunindo coleções de entidades e permitindo que serviços gravem e consultem dados sem dependência de um repositório externo.

## Conceitos de POO Aplicados

- Encapsulamento de Coleções Globais: as listas internas são privadas e somente leitura (`private readonly`), preservando a integridade dos dados e evitando modificações externas diretas.
- Isolamento de Persistência: a classe concentra a responsabilidade de armazenar entidades em um único ponto, separando a lógica de memória da lógica de negócio e tornando a aplicação mais organizada e fácil de testar.
- Exposição Controlada: as coleções são expostas apenas como `IReadOnlyList<T>`, permitindo que outros componentes leiam os dados sem poder alterá-los diretamente.
- Métodos de Adição Simples: ações de persistência são realizadas por métodos públicos dedicados, que recebem cada entidade e gravam no armazenamento em memória.

## Código Gerado

```csharp
namespace SistemaLaboratorioAcademico.Application;

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
```
