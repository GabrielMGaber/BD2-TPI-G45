using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}