# Consolidação do Fluxo de Aplicação

## Objetivo
Este documento descreve a integração entre a interface de console e a nova camada de aplicação do sistema de laboratório acadêmico. O ponto de entrada principal (`Program.cs`) passou a consumir diretamente o `ProgramaPrototipacaoService`, usando um repositório em memória (`InMemoryLaboratoryStore`) para simular dados existentes.

## Fluxo Integrado

1. Instanciação do store em memória
   - `var store = new InMemoryLaboratoryStore();`
   - O store mantém coleções simuladas de `Estudante`, `Professor`, `LaboratorioMaker`, `ProgramaPrototipacao` e `Especialista`.

2. Cadastro de atores existentes no store
   - Cria um `Estudante` com ID 1.
   - Cria um `Professor` com ID 1.
   - Cria um `LaboratorioMaker` com ID 1.
   - Esses atores são adicionados ao store antes da execução do serviço de aplicação.

3. Instanciação do serviço de aplicação
   - `var programaService = new ProgramaPrototipacaoService(store);`
   - O serviço utiliza o store para buscar entidades e persistir o programa criado.

4. Criação do input e chamada do serviço
   - `CreateProgramaInput` é montado com:
     - `Nome` do programa
     - `CoordenadorId = 1`
     - `OrientadorId = 1`
     - `LaboratorioId = 1`
   - `var resultado = programaService.Create(input);`

5. Verificação do resultado
   - Se `resultado.IsSuccess` for verdadeiro, os dados retornados em `resultado.Value` são impressos no console.
   - Se houver falha, a mensagem amigável de erro é exibida.

6. Teste de invariante com input inválido
   - Envia um `CreateProgramaInput` com `Nome` vazio.
   - O serviço captura internamente a exceção de domínio (`ArgumentException`) e retorna um `OperationResult` de falha.
   - O console demonstra que o fluxo não quebra e que o erro é tratado de forma amigável.

## Benefícios desse ajuste

- Centraliza a lógica de criação de programas na camada de aplicação, respeitando o padrão proposto pelo ConsoleApp do professor.
- Separa a orquestração de cenário (dados simulados) do comportamento do domínio.
- Permite demonstrar o tratamento de falhas com um input inválido, reforçando a robustez do serviço.

## Observações

- O `Program.cs` agora serve como orquestrador do fluxo de aplicação, sem criar programas diretamente no domínio.
- A camada de aplicação permanece responsável por validar a existência das entidades e capturar exceções de domínio.
