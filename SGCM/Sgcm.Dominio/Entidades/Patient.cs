using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgcm.Dominio.Entidades
{
    public class Patient
    {
        //pac_id, pac_personid, pac_hcid, pac_state

        public string Pac_id { get; set; }
        public string Pac_personId { get; set; }
        public int Pac_hcId { get; set; }
        public int Pac_state { get; set; }
    }
}