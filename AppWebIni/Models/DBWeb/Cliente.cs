using System;
using System.Collections.Generic;

#nullable disable

namespace AppWebIni.Models.DBWeb
{
    public partial class Cliente
    {
        public Cliente()
        {
            Tikets = new HashSet<Tiket>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tiket> Tikets { get; set; }
    }
}
