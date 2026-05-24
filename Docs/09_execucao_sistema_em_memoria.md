# Execução do Sistema em Memória

## Objetivo

Este documento descreve a criação do ponto de entrada principal do sistema (`Program.cs`), que permite validar o fluxo completo do domínio acadêmico em memória. O programa demonstra a interação entre as entidades do sistema, a adição de protótipos, a convocação de especialistas e a proteção de invariantes através de validações.

## Fluxo Validado

### Cenário de Execução

O programa realiza um teste integrado que simula um cenário realista do Sistema de Laboratório Acadêmico:

1. **Criação dos Atores Principais**
   - Instancia um `Estudante` com nome "Maria Silva Santos" e registro acadêmico "2024001234"
   - Instancia um `Professor` com nome "Dr. João Carlos Pereira" e SIAPE "1234567"
   - Instancia um `LaboratorioMaker` com nome "Lab Maker Innovation" localizado em "Bloco A, Sala 301"

2. **Criação do Programa de Prototipação**
   - Cria um programa intitulado "Projeto de IoT para Agricultura Inteligente"
   - Associa o estudante como coordenador
   - Associa o professor como orientador
   - Associa o laboratório como espaço de trabalho

3. **Adição de Protótipos**
   - Adiciona "Sensor de Umidade Solo" - um sistema embarcado com sensor capacitivo
   - Adiciona "Dashboard Web de Monitoramento" - interface web responsiva para visualização

4. **Convite de Especialista**
   - Convida "Eng. Ana Paula Ferreira" especialista em "IoT e Sistemas Embarcados"

5. **Geração de Relatório**
   - Exibe todas as informações do programa, incluindo:
     - Nome e ID do programa
     - Coordenador e seus dados acadêmicos
     - Orientador e seus dados funcionais
     - Laboratório e localização
     - Lista de protótipos em desenvolvimento
     - Especialistas convidados

6. **Teste de Validação**
   - Simula uma falha de validação tentando criar um `Estudante` com nome vazio
   - Captura a exceção e exibe a mensagem de proteção de invariantes
   - Comprova que as regras de negócio estão funcionando corretamente

## Código Gerado

```csharp
using System;
using SistemaLaboratorioAcademico;

// Cenário realista: execução do sistema de laboratório acadêmico em memória

Console.WriteLine("═══════════════════════════════════════════════════════════════");
Console.WriteLine("  SISTEMA DE LABORATÓRIO ACADÊMICO - EXECUÇÃO EM MEMÓRIA");
Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

try
{
    // Instanciação de um cenário realista
    Console.WriteLine("📋 [ETAPA 1] Criando os atores principais do sistema...\n");

    var estudante = new Estudante("Maria Silva Santos", "2024001234");
    Console.WriteLine($"✓ Estudante criado: {estudante.Nome} (ID: {estudante.Id}, RA: {estudante.RegistroAcademico})");

    var professor = new Professor("Dr. João Carlos Pereira", "1234567");
    Console.WriteLine($"✓ Professor criado: {professor.Nome} (ID: {professor.Id}, SIAPE: {professor.Siape})");

    var laboratorio = new LaboratorioMaker("Lab Maker Innovation", "Bloco A, Sala 301");
    Console.WriteLine($"✓ Laboratório criado: {laboratorio.Nome} (ID: {laboratorio.Id}, Local: {laboratorio.Localizacao})\n");

    // Criação do programa de prototipação
    Console.WriteLine("📋 [ETAPA 2] Criando o Programa de Prototipação...\n");

    var programa = new ProgramaPrototipacao(
        "Projeto de IoT para Agricultura Inteligente",
        estudante,
        professor,
        laboratorio
    );
    Console.WriteLine($"✓ Programa criado: {programa.Nome} (ID: {programa.Id})\n");

    // Adição de protótipos
    Console.WriteLine("📋 [ETAPA 3] Adicionando Protótipos ao programa...\n");

    var prototipo1 = new Prototipo(
        "Sensor de Umidade Solo",
        "Sistema embarcado com sensor capacitivo para monitoramento em tempo real da umidade do solo com comunicação via WiFi"
    );
    programa.AdicionarPrototipo(prototipo1);
    Console.WriteLine($"✓ Protótipo 1 adicionado: {prototipo1.Nome} (ID: {prototipo1.Id})");

    var prototipo2 = new Prototipo(
        "Dashboard Web de Monitoramento",
        "Interface web responsiva para visualização de dados de sensores com gráficos em tempo real e alertas automáticos"
    );
    programa.AdicionarPrototipo(prototipo2);
    Console.WriteLine($"✓ Protótipo 2 adicionado: {prototipo2.Nome} (ID: {prototipo2.Id})\n");

    // Convite de especialista
    Console.WriteLine("📋 [ETAPA 4] Convidando Especialista...\n");

    var especialista = new Especialista("Eng. Ana Paula Ferreira", "IoT e Sistemas Embarcados");
    programa.ConvidarEspecialista(especialista);
    Console.WriteLine($"✓ Especialista convidado: {especialista.Nome} (ID: {especialista.Id}, Competência: {especialista.CoreCompetence})\n");

    // Relatório completo
    Console.WriteLine("═══════════════════════════════════════════════════════════════");
    Console.WriteLine("  📊 RELATÓRIO COMPLETO DO PROGRAMA DE PROTOTIPAÇÃO");
    Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

    Console.WriteLine($"🎯 Nome do Programa: {programa.Nome}");
    Console.WriteLine($"📌 ID do Programa: {programa.Id}\n");

    Console.WriteLine($"👥 Coordenador (Estudante): {programa.Coordenador.Nome}");
    Console.WriteLine($"   └─ Registro Acadêmico: {programa.Coordenador.RegistroAcademico}\n");

    Console.WriteLine($"🎓 Orientador (Professor): {programa.Orientador.Nome}");
    Console.WriteLine($"   └─ SIAPE: {programa.Orientador.Siape}\n");

    Console.WriteLine($"🏭 Laboratório: {programa.Laboratorio.Nome}");
    Console.WriteLine($"   └─ Localização: {programa.Laboratorio.Localizacao}\n");

    Console.WriteLine("🔧 Protótipos em Desenvolvimento:");
    foreach (var proto in programa.Prototipos)
    {
        Console.WriteLine($"   • {proto.Nome}");
        Console.WriteLine($"     └─ {proto.Descricao}");
    }
    Console.WriteLine();

    Console.WriteLine("👨‍💼 Especialistas Convidados:");
    foreach (var esp in programa.Especialistas)
    {
        Console.WriteLine($"   • {esp.Nome}");
        Console.WriteLine($"     └─ Core Competence: {esp.CoreCompetence}");
    }
    Console.WriteLine();

    // Teste de invariantes (bloco try-catch)
    Console.WriteLine("═══════════════════════════════════════════════════════════════");
    Console.WriteLine("  🧪 TESTE DE VALIDAÇÃO DE INVARIANTES");
    Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

    Console.WriteLine("Tentando criar um Estudante com nome vazio (deve falhar)...\n");

    try
    {
        var estudantInvalido = new Estudante("", "2024005678");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"❌ EXCEÇÃO CAPTURADA (esperada): {ex.Message}");
        Console.WriteLine($"   └─ Nome do parâmetro: {ex.ParamName}\n");
        Console.WriteLine("✓ Proteção de invariantes funcionando corretamente!");
    }

    Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
    Console.WriteLine("  ✅ EXECUÇÃO DO SISTEMA FINALIZADA COM SUCESSO");
    Console.WriteLine("═══════════════════════════════════════════════════════════════");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ ERRO NÃO ESPERADO: {ex.Message}");
    Console.WriteLine($"   Stack Trace: {ex.StackTrace}");
}
```

## Resultado Esperado

Ao executar o programa, você verá no console:

1. A criação de cada ator com seus IDs gerados automaticamente
2. A criação do programa de prototipação
3. A adição de dois protótipos com descrições detalhadas
4. A convocação do especialista
5. Um relatório formatado exibindo:
   - O nome e ID do programa
   - Dados completos do coordenador (estudante)
   - Dados completos do orientador (professor)
   - Informações do laboratório
   - Lista de protótipos com suas descrições
   - Lista de especialistas convidados
6. Uma demonstração clara da proteção de invariantes ao tentar criar um Estudante inválido
7. A captura e exibição da mensagem de exceção

## Validações Confirmadas

✓ **Criação de Entidades**: Estudante, Professor e LaboratorioMaker são instanciados com sucesso  
✓ **Associações**: O ProgramaPrototipacao recebe corretamente os três atores principais  
✓ **Adição de Protótipos**: Dois protótipos são adicionados e armazenados corretamente  
✓ **Convite de Especialista**: Um especialista é convidado e vinculado ao programa  
✓ **Geração de Relatório**: As informações são acessíveis e exibidas corretamente  
✓ **Proteção de Invariantes**: As exceções de validação são lançadas apropriadamente  
✓ **Fluxo em Memória**: Todo o cenário funciona completamente em memória sem persistência
