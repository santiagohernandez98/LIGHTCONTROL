using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 /*   pqrs  modelo
  */ 
  
namespace CapaModelo
{
    public class PQRS
    {
        public int id { get; set; }
        public DateTime fecha_registro { get; set; }
        public string canal { get; set; }
        public string tipo_pqrs { get; set; }
        public string referencia { get; set; }
        public string documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public string descripcion_afectacion { get; set; }
        public string tipo_alumbrado { get; set; }
        public string estado { get; set; }
        public string oberservaciones { get; set; }
    }
}
