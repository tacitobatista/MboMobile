﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MbOMobile.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
