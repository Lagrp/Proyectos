namespace Sgcm.App.Services
{
    public class PatientService
    {
        private IPatientRepository _patientRepository;
        private PersonService _personService;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
            _personService = new PersonService();
        }

        public async Task<Patients> GetPatientsHandlerAsync()
        {
            var patients = await _patientRepository.GeatAllAsync();
            if (patients == null)
                return null;
            var list = new Patients();
            foreach (Patient patient in patients)
            {
                if (patient.Pac_state == 1)
                {
                    var patientDto = new PatientDto
                    {
                        Patient_id = patient.Pac_id,
                        Pac_person = await _personService.GetPersonHandlerAsync(patient.Pac_id),
                        Pac_hcid = patient.Pac_hcId,
                        Pac_state = patient.Pac_state,
                    };
                    list.Add(patientDto);
                }
            };
            return list;
        }

        public async Task<int> SavePatientAsync(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Pac_id = patientDto.Patient_id,
                Pac_personId = patientDto.Pac_person.Person_Id,
                Pac_state = patientDto.Pac_state,
            };
            var result = await _patientRepository.SaveAsync(patient);
            return result;
        }
    }
}