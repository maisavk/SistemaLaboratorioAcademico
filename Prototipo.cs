using System;

namespace SistemaLaboratorioAcademico
{
    public sealed class Prototipo
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Prototipo(string nome, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do protótipo é obrigatório e não pode ser nulo, vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição do protótipo é obrigatória e não pode ser nula, vazia ou composta apenas por espaços em branco.", nameof(descricao));
            }

            Id = _nextId++;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
