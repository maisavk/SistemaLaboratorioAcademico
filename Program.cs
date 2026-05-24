using System;
using SistemaLaboratorioAcademico;
using SistemaLaboratorioAcademico.Application;
using SistemaLaboratorioAcademico.Application.DTOs.ProgramaPrototipacao;
using SistemaLaboratorioAcademico.Application.Services;

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("  SISTEMA DE LABORATÓRIO ACADÊMICO - FLUXO DE APLICAÇÃO");
Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

var store = new InMemoryLaboratoryStore();

var estudante = new Estudante("Maria Silva Santos", "2024001234");
var professor = new Professor("Dr. João Carlos Pereira", "1234567");
var laboratorio = new LaboratorioMaker("Lab Maker Innovation", "Bloco A, Sala 301");

store.AddEstudante(estudante);
store.AddProfessor(professor);
store.AddLaboratorio(laboratorio);

Console.WriteLine("📋 [ETAPA 1] Dados de atores carregados no store:");
Console.WriteLine($"  - Estudante: {estudante.Nome} (ID: {estudante.Id})");
Console.WriteLine($"  - Professor: {professor.Nome} (ID: {professor.Id})");
Console.WriteLine($"  - Laboratório: {laboratorio.Nome} (ID: {laboratorio.Id})\n");

var programaService = new ProgramaPrototipacaoService(store);

var input = new CreateProgramaInput
{
    Nome = "Programa de Prototipação Acadêmica",
    CoordenadorId = estudante.Id,
    OrientadorId = professor.Id,
    LaboratorioId = laboratorio.Id
};

Console.WriteLine("📋 [ETAPA 2] Executando serviço de aplicação para criar programa...");
var resultado = programaService.Create(input);

if (resultado.IsSuccess)
{
    Console.WriteLine("✅ Programa criado com sucesso!");
    Console.WriteLine($"  ID: {resultado.Value?.Id}");
    Console.WriteLine($"  Nome: {resultado.Value?.Nome}");
    Console.WriteLine($"  Coordenador: {resultado.Value?.CoordenadorNome} (ID: {resultado.Value?.CoordenadorId})");
    Console.WriteLine($"  Orientador: {resultado.Value?.OrientadorNome} (ID: {resultado.Value?.OrientadorId})");
    Console.WriteLine($"  Laboratório: {resultado.Value?.LaboratorioNome} (ID: {resultado.Value?.LaboratorioId})\n");
}
else
{
    Console.WriteLine("❌ Falha ao criar programa:");
    Console.WriteLine($"  {resultado.Message}\n");
}

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("  🧪 TESTE DE INVARIANTE COM INPUT INVÁLIDO");
Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

var invalidInput = new CreateProgramaInput
{
    Nome = string.Empty,
    CoordenadorId = estudante.Id,
    OrientadorId = professor.Id,
    LaboratorioId = laboratorio.Id
};

var invalidResult = programaService.Create(invalidInput);

if (invalidResult.IsSuccess)
{
    Console.WriteLine("⚠️ Resultado inesperado: programa criado com input inválido.");
    Console.WriteLine($"  ID: {invalidResult.Value?.Id}");
    Console.WriteLine($"  Nome: {invalidResult.Value?.Nome}\n");
}
else
{
    Console.WriteLine("✅ Invariante do domínio validado corretamente.");
    Console.WriteLine($"  Mensagem de falha: {invalidResult.Message}\n");
}

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("  ✅ EXECUÇÃO DO CONSOLE FINALIZADA");
Console.WriteLine("═══════════════════════════════════════════════════════════════");
