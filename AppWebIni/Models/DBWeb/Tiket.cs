using System;
using System.Collections.Generic;

#nullable disable

namespace AppWebIni.Models.DBWeb
{
    public partial class Tiket
    {
        public Tiket()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public int? Cliente { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
