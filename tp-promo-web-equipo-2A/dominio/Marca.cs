﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public int ID { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public override string ToString() { return Descripcion; }
    }
}
