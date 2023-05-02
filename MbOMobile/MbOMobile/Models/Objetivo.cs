using System;
using System.Collections.Generic;
using System.Text;

namespace MbOMobile.Models
{
    public class Objetivo
    {
        public int Id { get; set; }
        public int CicloId { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioAprovadorId { get; set; }
        public int TipoObjetivoId { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Implementacao { get; set; }
        public string Meta { get; set; }
        public string Metrica { get; set; }
        public double Peso { get; set; }
        public double Percentual_Atingimento { get; set; }
        public int Status { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string ObservacaoApr { get; set; }
        public string ObservacaoRep { get; set; }

    }
}
