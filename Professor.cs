using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class Professor
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Siape { get; private set; }

        public Professor(string nome, string siape)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do professor é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(siape))
            {
                throw new ArgumentException("O SIAPE é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(siape));
            }

            Id = _nextId++;
            Nome = nome;
            Siape = siape;
        }
    }
}
