using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class Consulta
    {
        public int Id { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
        public override string ToString()
        {
            return "N° " + Id + " - " + Mascota.Nombre + " - " + Fecha.ToShortDateString();
        }
    }
}