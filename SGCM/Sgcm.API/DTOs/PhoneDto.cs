using System.Collections.ObjectModel;

namespace Sgcm.App.DTOs
{
    public class PersonPhones : ObservableCollection<PhoneDto>
    {
    }

    public class PhoneDto
    {
        //pho_numero, pho_personId, pho_tipoId, pho_operId, pho_state
        public string? Pho_personId { get; set; }

        public string? Pho_number { get; set; }
        public int Pho_typeId { get; set; }
        public int Pho_operatorId { get; set; }
        public int Pho_state { get; set; }
    }
}