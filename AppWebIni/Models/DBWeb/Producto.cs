using System;
using System.Collections.Generic;

#nullable disable

namespace AppWebIni.Models.DBWeb
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public double? PrecioPub { get; set; }
        public int? Cantidad { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
