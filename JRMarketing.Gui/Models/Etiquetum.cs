﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRMarketing.Gui.Models
{
    public class Etiquetum
    {
        public int Id { get; set; }
        public string NombreEtiqueta { get; set; }
    }

    public class EtiquetumName
    {
        public string NombreEtiqueta { get; set; }
        public int IdRestau { get; set; }
        public int IdEtiqueta { get; set; }
    }
}