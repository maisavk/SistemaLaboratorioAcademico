using System;

namespace SistemaLaboratorioAcademico.Domain.Entities
{
    public sealed class LaboratorioMaker
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Localizacao { get; private set; }

        public LaboratorioMaker(string nome, string localizacao)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do laboratório é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(localizacao))
            {
                throw new ArgumentException("A localização do laboratório é obrigatória e não pode ser vazia ou composta apenas por espaços em branco.", nameof(localizacao));
            }

            Id = _nextId++;
            Nome = nome;
            Localizacao = localizacao;
        }
    }
}
