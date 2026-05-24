Objetivo:

Esta conversa isolou a criação da entidade central ProgramaPrototipacao e suas associações 1:1 obrigatórias (Coordenador do tipo Estudante, Orientador do tipo Professor e Laboratorio do tipo LaboratorioMaker). O foco foi gerar a entidade de domínio com validações que impeçam instâncias inválidas em memória.

Conceitos de POO Aplicados:

Proteção de Invariantes em Associações de Objetos: o construtor valida que todas as dependências obrigatórias (Coordenador, Orientador e Laboratorio) não sejam nulas, e que o `Nome` não seja nulo ou vazio. Isso garante que a classe não possa ser instanciada em um estado inconsistente.

Encapsulamento: todas as propriedades usam `private set` para impedir modificações externas diretas após a criação, preservando a integridade do objeto.

Código Gerado:

```csharp
using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class ProgramaPrototipacao
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Estudante Coordenador { get; private set; }
        public Professor Orientador { get; private set; }
        public LaboratorioMaker Laboratorio { get; private set; }

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
    }
}
```
