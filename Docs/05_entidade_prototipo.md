Objetivo:

Esta conversa isolou a criação da entidade `Prototipo` para o domínio do sistema.

Conceitos de POO Aplicados:

- Encapsulamento: todas as propriedades (`Id`, `Nome` e `Descricao`) usam `private set` para impedir alterações externas diretas após a criação do objeto.
- Geração de ID: o `Id` é gerado automaticamente de forma sequencial na memória usando o campo `static` `_nextId`, começando em `1`.
- Proteção de Invariantes: o construtor valida `Nome` e `Descricao` contra valores nulos, vazios ou compostos apenas por espaços em branco e lança `ArgumentException` com mensagem clara quando a entrada é inválida.

Código Gerado:

```csharp
using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class Prototipo
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Prototipo(string nome, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do protótipo é obrigatório e não pode ser nulo, vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição do protótipo é obrigatória e não pode ser nula, vazia ou composta apenas por espaços em branco.", nameof(descricao));
            }

            Id = _nextId++;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
```
