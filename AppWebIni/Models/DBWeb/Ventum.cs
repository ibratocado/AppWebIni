using System;
using System.Collections.Generic;

#nullable disable

namespace AppWebIni.Models.DBWeb
{
    public partial class Ventum
    {
        public int Id { get; set; }
        public int? Tiket { get; set; }
        public int? Producto { get; set; }
        public int? Cantidad { get; set; }
        public string Total { get; set; }

        public virtual Producto ProductoNavigation { get; set; }
        public virtual Tiket TiketNavigation { get; set; }
    }
}
