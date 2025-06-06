﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Evento
    {
        public int id_evento { get; set; }
        public string nombre_evento { get; set; }
        public string lugar_evento { get; set; }
        public string descripcion_evento { get; set; }
        public DateTime fecha_inicio_evento { get; set; }
        public DateTime fecha_fin_evento { get; set; }
        public int capacidad_max_evento { get; set; }
        public List<Usuario> Asistentes { get; set; }

        public Evento()
        {
            Asistentes = new List<Usuario>();
        }

        public int NumeroAsistentes
        {
            get { return Asistentes?.Count ?? 0; }
        }
    }
}
