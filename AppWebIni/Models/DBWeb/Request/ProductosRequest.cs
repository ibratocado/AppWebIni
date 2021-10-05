using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebIni.Models.DBWeb
{
    public class ProductosRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double PrecioPub { get; set; }
        public int Cantidad { get; set; }

    }
}
