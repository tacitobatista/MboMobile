using MbOMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MbOMobile.Services
{
    public static class TransportadorDados
    {
        public static string Email;

        public static Usuario usuario;

        public static List<Objetivo> objetivos { get; set; }

        public static List<ObjetivoComum> objetivosComuns { get; set; }
    }
}
