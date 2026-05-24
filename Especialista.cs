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
