using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class DetalleConsulta
    {
        public int Id { get; set; }
        public Medicamento Medicamento { get; set; }
        public int Cantidad { get; set; }
    }
}
