# Objetivo

Explicar que esta conversa isolou a criação da entidade base `LaboratorioMaker`.

# Conceitos de POO Aplicados

- Encapsulamento: uso de `private set` em propriedades para impedir alterações externas.
- Geração de ID automática em memória: `Id` incrementa sequencialmente com um campo estático interno.
- Proteção de Invariantes: validação no construtor contra `null`, strings vazias ou compostas apenas por espaços em branco.

# Código Gerado

```csharp
using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class LaboratorioMaker
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Localizacao { get; private set; }

        public LaboratorioMaker(string nome, string localizacao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do laboratório é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(localizacao))
            {
                throw new ArgumentException("A localização do laboratório é obrigatória e não pode ser vazia ou composta apenas por espaços em branco.", nameof(localizacao));
            }

            Id = _nextId++;
            Nome = nome;
            Localizacao = localizacao;
        }
    }
}
```
