using System;
using System.Collections.Generic;

namespace SistemaLaboratorioAcademico
{
    public sealed class ProgramaPrototipacao
    {
        private readonly List<Prototipo> _prototipos = new();
        private readonly List<Especialista> _especialistas = new();
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Estudante Coordenador { get; private set; }
        public Professor Orientador { get; private set; }
        public LaboratorioMaker Laboratorio { get; private set; }

        public IReadOnlyCollection<Prototipo> Prototipos => _prototipos;
        public IReadOnlyCollection<Especialista> Especialistas => _especialistas;

        public ProgramaPrototipacao(string nome, Estudante coordenador, Professor orientador, LaboratorioMaker laboratorio)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome do programa de prototipação é obrigatório e não pode ser vazio ou composto apenas por espaços em branco.", nameof(nome));
            }

            if (coordenador is null)
            {
                throw new ArgumentNullException(nameof(coordenador), "O coordenador (Estudante) é obrigatório e não pode ser nulo.");
            }

            if (orientador is null)
            {
                throw new ArgumentNullException(nameof(orientador), "O orientador (Professor) é obrigatório e não pode ser nulo.");
            }

            if (laboratorio is null)
            {
                throw new ArgumentNullException(nameof(laboratorio), "O laboratório (LaboratorioMaker) é obrigatório e não pode ser nulo.");
            }

            Id = _nextId++;
            Nome = nome;
            Coordenador = coordenador;
            Orientador = orientador;
            Laboratorio = laboratorio;
        }

        public void AdicionarPrototipo(Prototipo prototipo)
        {
            if (prototipo is null)
            {
                throw new ArgumentNullException(nameof(prototipo), "O protótipo não pode ser nulo.");
            }

            _prototipos.Add(prototipo);
        }

        public void ConvidarEspecialista(Especialista especialista)
        {
            if (especialista is null)
            {
                throw new ArgumentNullException(nameof(especialista));
            }

            if (!_especialistas.Contains(especialista))
            {
                _especialistas.Add(especialista);
                especialista.VincularPrograma(this);
            }
        }
    }
}
