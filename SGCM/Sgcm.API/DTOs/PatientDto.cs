using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgcm.App.DTOs
{
    public class Patients : ObservableCollection<PatientDto>
    { }

    public class PatientDto
    {
        //pac_id, pac_personid, pac_hcid, pac_state

        public string Patient_id { get; set; }
        public PersonDto Pac_person { get; set; }
        public int Pac_hcid { get; set; }
        public int Pac_state { get; set; }
    }
}