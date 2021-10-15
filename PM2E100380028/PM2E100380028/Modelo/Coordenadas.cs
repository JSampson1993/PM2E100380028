using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E100380028.Modelo
{
   public class Coordenadas
    {
       [ PrimaryKey, AutoIncrement ]
        public int codigo { get; set; }

        [MaxLength(70)]
        public double latitud { get; set; }
        [MaxLength(70)]
        public double longitud { get; set; }
        public String descripcionL { get; set; }
        [MaxLength(70)]
        public String descripcionC { get; set; }
    }
}
