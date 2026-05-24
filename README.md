# SistemaLaboratorioAcademico

## Visão Geral

SistemaLaboratorioAcademico é um sistema de prova de conceito para modelar um ambiente acadêmico de prototipação, onde um estudante coordena um programa de prototipação com um professor orientador, um laboratório maker, protótipos em desenvolvimento e especialistas convidados.

## Estrutura da Solução

O projeto adota uma arquitetura em camadas para isolar o domínio e as regras de negócio das interfaces de usuário e componentes de transporte de dados:

- **Domain / Raiz:** Contém as entidades puras e a validação das invariantes de negócio (`Estudante`, `Professor`, `LaboratorioMaker`, `ProgramaPrototipacao`, `Prototipo`, `Especialista`).
- **Application/**: Camada que orquestra o fluxo da aplicação.
  - `Common/`: Central de persistência simulada em memória (`InMemoryLaboratoryStore`).
  - `DTOs/`: Objetos de transferência de dados para entrada e saída imutável (`CreateProgramaInput`, `ProgramaPrototipacaoDto`).
  - `Results/`: Envelopes estruturados para respostas de operações (`OperationResult`, `OperationResult<T>`).
  - `Services/`: Serviços de aplicação que executam casos de uso e tratam exceções (`ProgramaPrototipacaoService`).
- **Program.cs (ConsoleApp):** Ponto de entrada que consome a camada de aplicação de forma segura.

## Modelo de Domínio

```mermaid
classDiagram
    class Estudante {
        +int Id
        +string Nome
        +string RegistroAcademico
    }
    class Professor {
        +int Id
        +string Nome
        +string Siape
    }
    class LaboratorioMaker {
        +int Id
        +string Nome
        +string Localizacao
    }
    class ProgramaPrototipacao {
        +int Id
        +string Nome
    }
    class Prototipo {
        +int Id
        +string Nome
        +string Descricao
    }
    class Especialista {
        +int Id
        +string Nome
        +string CoreCompetence
    }

    ProgramaPrototipacao "1" --> "1" Estudante : Coordenador
    ProgramaPrototipacao "1" --> "1" Professor : Orientador
    ProgramaPrototipacao "1" --> "1" LaboratorioMaker : Laboratório
    ProgramaPrototipacao "1" --> "N" Prototipo : Prototipos
    ProgramaPrototipacao "1" --> "N" Especialista : Especialistas
    Especialista "N" --> "N" ProgramaPrototipacao : Programas
```

## Fluxo de Inicialização

```mermaid
sequenceDiagram
    participant Console as Console
    participant Main as Program.cs
    participant Store as InMemoryLaboratoryStore
    participant Service as ProgramaPrototipacaoService
    participant Domínio as Domínio (Entidades)

    Console->>Main: Inicia execução do sistema
    Main->>Store: Adiciona instâncias prévias (Estudante, Professor, Laboratorio)
    Main->>Service: Invoca Create(CreateProgramaInput)
    Service->>Store: Verifica existência dos IDs cadastrados
    Service->>Domínio: Instancia ProgramaPrototipacao (Valida invariantes)
    Service->>Store: AddPrograma(programa)
    Service->>Main: Retorna OperationResult<ProgramaPrototipacaoDto>
    Main->>Console: Exibe relatório detalhado de sucesso
    Main->>Service: Invoca Create com Input inválido (Nome vazio)
    Service->>Domínio: Instancia com dados inválidos
    Note over Domínio: Dispara ArgumentException
    Service->>Service: Captura exceção no bloco try-catch
    Service->>Main: Retorna OperationResult.Failure(mensagem)
    Main->>Console: Exibe erro tratado amigavelmente sem crash
```

## Tabela de Rastreabilidade

| Documento | Descrição |
| --- | --- |
| `01_entidade_estudante.md` | Entidade Estudante |
| `02_entidade_professor.md` | Entidade Professor |
| `03_entidade_laboratorio_maker.md` | Entidade LaboratorioMaker |
| `04_entidade_programa_prototipacao.md` | Entidade ProgramaPrototipacao |
| `05_entidade_prototipo.md` | Entidade Prototipo |
| `06_associacao_programa_prototipos.md` | Associação entre ProgramaPrototipacao e Prototipo |
| `07_entidade_especialista.md` | Entidade Especialista |
| `08_associacao_muitos_para_muitos.md` | Associação N:N entre ProgramaPrototipacao e Especialista |
| `09_execucao_sistema_em_memoria.md` | Cenário de execução inicial em memória do sistema |
| `10_documentacao_readme_e_diagramas.md` | Documentação da geração do README e diagramas iniciais |
| `11_application_results_e_dtos.md` | Introdução de DTOs e envelopes OperationResult |
| `12_application_store_em_memoria.md` | Central de persistência simulada com InMemoryLaboratoryStore |
| `13_application_service_programa.md` | Lógica de orquestração de fluxo com ProgramaPrototipacaoService |
| `14_consolidacao_fluxo_aplicacao.md` | Integração do fluxo fim a fim no Program.cs e testes de invariantes |
| `15_atualizacao_requisitos_readme.md` | Revisão de pré-requisitos, instruções de build e documentação técnica |

## Instruções de Execução

Abra um terminal no diretório do projeto SistemaLaboratorioAcademico.

## Pré-requisitos

.NET 10 SDK instalado — necessário para compilar e executar o projeto.

Git — para clonar e versionar o repositório.

IDE/Editor de código: Visual Studio Code (com extensões C#) ou Visual Studio 2022.

Antes de executar, compile o projeto para restaurar dependências e validar a compilação:

```bash
dotnet build
```

Depois de compilado com sucesso, execute o sistema:

```bash
dotnet run
```

O sistema será iniciado em memória e exibirá o relatório do programa de prototipação e a validação de invariantes.

Observação: o projeto foi construído para .NET 10.0, portanto certifique-se de ter o SDK apropriado instalado.
