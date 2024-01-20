using Sgcm.App.DTOs;
using Sgcm.App.Services;
using System.Threading.Tasks;

namespace Sgcm.UI.Desktop.VistaModelo
{
    public class PatientVM : NotifyVM
    {
        private Patients _patients;
        private PatientService _patientService;

        public PatientVM()
        {
            _patientService = new PatientService();
            Intialice();
        }

        public Patients Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        private void Intialice()
        {

            Task.Run(async () =>
            {
                Patients = await _patientService.GetPatientsHandlerAsync();

            }).GetAwaiter().GetResult();
        }
    }
}