using System;
using System.Collections.Generic;

namespace SistemaLaboratorioAcademico
{
    public sealed class Especialista
    {
        private static int _nextId = 1;
        private readonly List<ProgramaPrototipacao> _programas = new();

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CoreCompetence { get; private set; }
        public IReadOnlyCollection<ProgramaPrototipacao> Programas => _programas;

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

        public void VincularPrograma(ProgramaPrototipacao programa)
        {
            if (programa is null)
            {
                throw new ArgumentNullException(nameof(programa));
            }

            if (!_programas.Contains(programa))
            {
                _programas.Add(programa);
            }
        }
    }
}
