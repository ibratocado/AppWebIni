using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebIni.Models.DBWeb.Respons
{
    public class Respon
    {
        public int Estado { get; set; }
        public string Mensage { get; set; }
        public object Data { get; set; }

        public Respon()
        {
            Estado = 1;
            Mensage = "exito";
        }
    }
}
