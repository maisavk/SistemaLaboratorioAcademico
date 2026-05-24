## Objetivo

Esta conversa isolou a criação da entidade de domínio `Especialista`, representando um especialista convidado no sistema. O arquivo contém a definição da classe e explica os principais conceitos de projeto aplicados.

## Conceitos de POO Aplicados

Encapsulamento: As propriedades `Id`, `Nome` e `CoreCompetence` são expostas com `public` getters e `private set`, garantindo que o estado só possa ser alterado internamente pela classe, preservando invariantes.

Geração de ID: Um campo estático `_nextId` inicializado em 1 é utilizado para gerar identificadores sequenciais em memória; cada instância recebe um `Id` único no construtor através de `Id = _nextId++`.

Proteção de Invariantes: O construtor valida os parâmetros obrigatórios `nome` e `coreCompetence`. Se qualquer um for nulo, vazio ou composto apenas por espaços em branco, é lançada uma `ArgumentException` com mensagem clara, preservando as regras de consistência da entidade.

## Código Gerado

```csharp
using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class Especialista
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CoreCompetence { get; private set; }

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
    }
}
```
