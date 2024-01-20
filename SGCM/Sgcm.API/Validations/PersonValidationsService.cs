namespace Sgcm.App.Validations
{
    public static class PersonValidationsService
    {
        public static bool PersonValidation(PersonDto? personDto, PersonPhones? phonesDto, PersonEmails? emailsDto)
        {
            if (personDto == null)
                return false;
            if (personDto.Person_Id == null) 
                return false;
            if (string.IsNullOrEmpty(personDto.Per_FirstName))
                return false;
            if (string.IsNullOrEmpty(personDto.Per_Surname))
                return false;
            if (string.IsNullOrEmpty(personDto.Per_SecondSurname))
                return false;
            if (personDto.Per_UbdisId < 10101)
                return false;
            if (string.IsNullOrEmpty(personDto.Per_Address))
                return false;
            if (phonesDto == null || phonesDto.Count < 1)
                return false;
            if (emailsDto == null || emailsDto.Count < 1)
                return false;
            //if (string.IsNullOrEmpty(personDto.Per_PatientId))
            //    return false;

            return true;
        }
    }
}