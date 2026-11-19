using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Matricula { get; set; }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }
    }
}