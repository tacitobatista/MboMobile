using System;
using System.Collections.Generic;
using System.Text;

namespace MbOMobile.Models
{
    public class ObjetivoComum
    {
        public int Id { get; set; }
        public int IdTipoObjetivo { get; set; }
        public int IdCategoria { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public DateTime Data_Implementacao { get; set; }
        public string Meta { get; set; }
        public string Metrica { get; set; }
    }
}
