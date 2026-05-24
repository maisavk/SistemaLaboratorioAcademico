## Objetivo

Descrever a associação 1:N entre `ProgramaPrototipacao` e seus múltiplos `Prototipo`, aplicada durante esta conversa.

## Conceitos de POO Aplicados

- **Composição/Agregação Forte**: `ProgramaPrototipacao` mantém a coleção de `Prototipo` como parte de sua responsabilidade, representando uma relação de vida útil controlada pelo programa.
- **Encapsulamento de Coleções**: A coleção interna é um campo privado (`_prototipos`) exposto externamente apenas como `IReadOnlyCollection<Prototipo>`, impedindo alterações diretas de código consumidor.
- **Proteção de Invariantes**: O método `AdicionarPrototipo` valida entradas e lança `ArgumentNullException` se o parâmetro for nulo, preservando o estado interno consistente.

## Código Gerado

```csharp
using System;
using System.Collections.Generic;

namespace SistemaLaboratorioAcademico
{
    public sealed class ProgramaPrototipacao
    {
        private readonly List<Prototipo> _prototipos = new();
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Estudante Coordenador { get; private set; }
        public Professor Orientador { get; private set; }
        public LaboratorioMaker Laboratorio { get; private set; }

        public IReadOnlyCollection<Prototipo> Prototipos => _prototipos;

        public ProgramaPrototipacao(string nome, Estudante coordenador, Professor orientador, LaboratorioMaker laboratorio)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do programa de prototação é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
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
    }
}
```

## Observações

- A propriedade `Prototipos` é somente leitura e garante que callers não possam modificar a coleção diretamente.
- Para remoção ou outras operações, criar métodos explícitos que protejam invariantes.
