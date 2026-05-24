# 08_associacao_muitos_para_muitos.md

## Objetivo

Explicar a associação N:N entre `ProgramaPrototipacao` e `Especialista`, onde um programa pode convidar vários especialistas e um especialista pode estar vinculado a vários programas.

## Conceitos de POO Aplicados

- Associação Bidirecional
  - A relação entre `ProgramaPrototipacao` e `Especialista` é bidirecional: cada lado mantém referência ao outro.
  - A consistência é preservada garantindo que, quando um especialista é convidado para um programa, o programa também é registrado no especialista.

- Encapsulamento de Coleções com `IReadOnlyCollection`
  - As coleções internas são mantidas como `List<T>` privadas (`_programas` e `_especialistas`).
  - A propriedade pública expõe apenas `IReadOnlyCollection<T>`, prevenindo modificações externas diretas e preservando o encapsulamento.

- Preservação da Consistência Bidirecional
  - `ProgramaPrototipacao.ConvidarEspecialista(Especialista especialista)` verifica nulo e evita duplicados.
  - Se o especialista não estiver presente, ele é adicionado e `especialista.VincularPrograma(this)` é invocado imediatamente.
  - `Especialista.VincularPrograma(ProgramaPrototipacao programa)` adiciona o programa somente se ele ainda não existir na lista interna.

## Código Gerado

### Especialista.cs

```csharp
using System;
using System.Collections.Generic;

namespace SistemaLaboratorioAcademico
{
    public sealed class Especialista
    {
        private static int _nextId = 1;
        private readonly List<ProgramaPrototipacao> _programas = new();

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CoreCompetence { get; private set; }
        public IReadOnlyCollection<ProgramaPrototipacao> Programas => _programas;

        public Especialista(string nome, string coreCompetence)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do especialista é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(coreCompetence))
            {
                throw new ArgumentException("A CoreCompetence é obrigatória e não pode ser vazia ou composta apenas por espaços em branco.", nameof(coreCompetence));
            }

            Id = _nextId++;
            Nome = nome;
            CoreCompetence = coreCompetence;
        }

        public void VincularPrograma(ProgramaPrototipacao programa)
        {
            if (programa is null)
            {
                throw new ArgumentNullException(nameof(programa));
            }

            if (!_programas.Contains(programa))
            {
                _programas.Add(programa);
            }
        }
    }
}
```

### ProgramaPrototipacao.cs

```csharp
using System;
using System.Collections.Generic;

namespace SistemaLaboratorioAcademico
{
    public sealed class ProgramaPrototipacao
    {
        private readonly List<Prototipo> _prototipos = new();
        private readonly List<Especialista> _especialistas = new();
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Estudante Coordenador { get; private set; }
        public Professor Orientador { get; private set; }
        public LaboratorioMaker Laboratorio { get; private set; }

        public IReadOnlyCollection<Prototipo> Prototipos => _prototipos;
        public IReadOnlyCollection<Especialista> Especialistas => _especialistas;

        public ProgramaPrototipacao(string nome, Estudante coordenador, Professor orientador, LaboratorioMaker laboratorio)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do programa de prototipação é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (coordenador is null)
            {
                throw new ArgumentNullException(nameof(coordenador), "O coordenador (Estudante) é obrigatório e não pode ser nulo.");
            }

            if (orientador is null)
            {
                throw new ArgumentNullException(nameof(orientador), "O orientador (Professor) é obrigatório e não pode ser nulo.");
            }

            if (laboratorio is null)
            {
                throw new ArgumentNullException(nameof(laboratorio), "O laboratório (LaboratorioMaker) é obrigatório e não pode ser nulo.");
            }

            Id = _nextId++;
            Nome = nome;
            Coordenador = coordenador;
            Orientador = orientador;
            Laboratorio = laboratorio;
        }

        public void AdicionarPrototipo(Prototipo prototipo)
        {
            if (prototipo is null)
            {
                throw new ArgumentNullException(nameof(prototipo), "O protótipo não pode ser nulo.");
            }

            _prototipos.Add(prototipo);
        }

        public void ConvidarEspecialista(Especialista especialista)
        {
            if (especialista is null)
            {
                throw new ArgumentNullException(nameof(especialista));
            }

            if (!_especialistas.Contains(especialista))
            {
                _especialistas.Add(especialista);
                especialista.VincularPrograma(this);
            }
        }
    }
}
```
