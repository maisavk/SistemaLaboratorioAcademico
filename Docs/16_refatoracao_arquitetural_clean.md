# 16. Refatoração Arquitetural: Organização em Camadas e Records para DTOs

## Objetivo
Registrar a aplicação do feedback técnico de refatoração, organizando o projeto em camadas e melhorando a modelagem dos DTOs com `record`.

## Mudanças aplicadas

- **DTOs atualizados para `record`**
  - `CreateProgramaInput.cs` agora define `public sealed record CreateProgramaInput`.
  - `ProgramaPrototipacaoDto.cs` agora define `public sealed record ProgramaPrototipacaoDto`.

- **Entidades centralizadas em camada de domínio**
  - Todos os arquivos de entidade (`Estudante.cs`, `Professor.cs`, `LaboratorioMaker.cs`, `ProgramaPrototipacao.cs`, `Prototipo.cs`, `Especialista.cs`) foram atualizados para o namespace `SistemaLaboratorioAcademico.Domain.Entities`.

- **Persistência isolada em camada de infraestrutura**
  - `InMemoryLaboratoryStore.cs` passou a usar o namespace `SistemaLaboratorioAcademico.Infrastructure.Persistence`.
  - O arquivo também recebeu `using SistemaLaboratorioAcademico.Domain.Entities;` para acessar as entidades do domínio.

- **Referências atualizadas**
  - `ProgramaPrototipacaoService.cs` e `Program.cs` receberam `using SistemaLaboratorioAcademico.Domain.Entities;` e `using SistemaLaboratorioAcademico.Infrastructure.Persistence;` para alinhar ao novo layout.

## Conceitos aplicados

- **Organização em Camadas**
  - Separei o código em camadas lógicas: `Domain.Entities` para as regras e objetos do domínio, `Infrastructure.Persistence` para a implementação de armazenamento em memória, e `Application` para o serviço de aplicação e DTOs.
  - Isso ajuda a manter dependências unidirecionais e facilita futuras evoluções, como migração para persistência real ou testes de unidade mais claros.

- **Records para DTOs**
  - `record` é uma construção C# indicada para tipos de dados que representam transporte de informações.
  - O uso de `record` traz imutabilidade semântica e simplifica o código de DTOs, deixando claro que esses objetos são destinados apenas a transportar dados.

## Resultado esperado

- Estrutura de projeto mais coerente e alinhada a boas práticas de arquitetura.
- DTOs mais seguros e expressivos.
- Dependências de namespace atualizadas para refletir a separação de domínio e infraestrutura.
