using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class Estudante
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string RegistroAcademico { get; private set; }

        public Estudante(string nome, string registroAcademico)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do estudante é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(registroAcademico))
            {
                throw new ArgumentException("O registro acadêmico é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(registroAcademico));
            }

            Id = _nextId++;
            Nome = nome;
            RegistroAcademico = registroAcademico;
        }
    }
}
