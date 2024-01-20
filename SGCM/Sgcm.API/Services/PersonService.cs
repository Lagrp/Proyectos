using Sgcm.App.ValueObjects;

namespace Sgcm.App.Services
{
    public class PersonService
    {
        private IPersonRepository _personRepository;
        private IPhoneRepository _phoneRepository;
        private IEmailRepository _emailRepository;
        private INetRepository _netRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
            _phoneRepository = new PhoneRepository();
            _emailRepository = new EmailRepository();
            _netRepository = new NetRepository();
        }

        #region QUERY'S

        public async Task<PersonDto> GetPersonHandlerAsync(string personId)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person == null)
            {
                return null;
            }
            else
            {
                return GetPersonDto(person);
            }
        }

        public async Task<PersonPhones> GetPhonesHandlerAsync(string personId)
        {
            var phones = await _phoneRepository.GetByFieldValueAsync(personId);
            if (phones == null) return null;
            var list = new PersonPhones();
            foreach (Phone phone in phones)
            {
                if (phone.Pho_state == 1)
                {
                    var phoneDto = new PhoneDto
                    {
                        Pho_number = phone.Pho_number,
                        Pho_personId = phone.Pho_personid,
                        Pho_operatorId = phone.Pho_operid,
                        Pho_typeId = phone.Pho_typeuse,
                        Pho_state = phone.Pho_state
                    };
                    list.Add(phoneDto);
                }
            };
            return list;
        }

        public async Task<PersonEmails> GetEmailsHandlerAsync(string personId)
        {
            var emails = await _emailRepository.GetByFieldValueAsync(personId);
            if (emails == null) return null;
            var list = new PersonEmails();
            foreach (Email email in emails)
            {
                if (email.Email_state == 1)
                {
                    var emailDto = new EmailDto
                    {
                        Email_link = email.Email_link,
                        Email_personId = email.Email_personid,
                        Email_type = email.Email_type,
                        Email_state = email.Email_state,
                    };
                    list.Add(emailDto);
                }
            };
            return list;
        }

        public async Task<PersonNets> GetNetsHandlerAsync(string personId)
        {
            var nets = await _netRepository.GetByFieldValueAsync(personId);
            if (nets == null) return null;
            var list = new PersonNets();
            foreach (Net net in nets)
            {
                if (net.Net_state == 1)
                {
                    var netDto = new NetDto
                    {
                        Net_url = net.Net_url,
                        Net_personid = net.Net_personid,
                        Net_nettype = net.Net_nettype,
                        Net_state = net.Net_state
                    };
                    list.Add(netDto);
                }
            };
            return list;
        }

        #endregion QUERY'S

        #region COMMAND'S

        public async Task<int> SavePersonAsync(PersonDto person) => await _personRepository.SaveAsync(GetPerson(person));

        public async Task<int> SavePhonesAsync(string personId, PersonPhones phoneDtos)
        {
            if (string.IsNullOrEmpty(personId))
                return 0;
            if (phoneDtos == null)
                return 1;

            int result = 0;
            var originalphones = (List<Phone>)await _phoneRepository.GetByFieldValueAsync(personId);
            if (originalphones == null)
            {
                originalphones = new List<Phone>();
                foreach (var phone in phoneDtos)
                    originalphones.Add(NewPhone(phone));
            }
            else
            {
                foreach (var phone in originalphones)
                    phone.Pho_state = 0;
                foreach (var phoneDto in phoneDtos)
                {
                    var phone = originalphones.Find(a => a.Pho_number == phoneDto.Pho_number);
                    if (phone != null)
                    {
                        phone.Pho_typeuse = phoneDto.Pho_typeId;
                        phone.Pho_operid = phoneDto.Pho_operatorId;
                        phone.Pho_personid = phoneDto.Pho_personId;
                        phone.Pho_state = 1;
                    }
                    else
                        originalphones.Add(NewPhone(phoneDto));
                }
            }

            foreach (var phone in originalphones)
                result += await _phoneRepository.SaveAsync(phone);
            return result;
        }

        public async Task<int> SaveEmailsAsync(string personId, PersonEmails emailDtos)
        {
            if (string.IsNullOrEmpty(personId))
                return 0;
            if (emailDtos == null)
                return 1;

            int result = 0;
            var originalEmails = (List<Email>)await _emailRepository.GetByFieldValueAsync(personId);
            if (originalEmails == null)
            {
                originalEmails = new List<Email>();
                foreach (var emailDto in emailDtos)
                    originalEmails.Add(NewEmail(emailDto));
            }
            else
            {
                foreach (var email in originalEmails)
                    email.Email_state = 0;
                foreach (var emailDto in emailDtos)
                {
                    var email = originalEmails.Find(a => a.Email_link == emailDto.Email_link);
                    if (email != null)
                    {
                        email.Email_personid = emailDto.Email_personId;
                        email.Email_type = emailDto.Email_type;
                        email.Email_state = 1;
                    }
                    else
                        originalEmails.Add(NewEmail(emailDto));
                }
            }

            foreach (var email in originalEmails)
                result += await _emailRepository.SaveAsync(email);
            return result;
        }

        public async Task<int> SaveNetsAsync(string personId, PersonNets netDtos)
        {
            if (string.IsNullOrEmpty(personId))
                return 0;
            if (netDtos == null)
                return 1;

            int result = 0;
            var originalNets = (List<Net>)await _netRepository.GetByFieldValueAsync(personId);
            if (originalNets == null)
            {
                originalNets = new List<Net>();
                foreach (var netDto in netDtos)
                    originalNets.Add(NewNet(netDto));
            }
            else
            {
                foreach (var net in originalNets)
                    net.Net_state = 0;
                foreach (var netDto in netDtos)
                {
                    var net = originalNets.Find(a => a.Net_url == netDto.Net_url);
                    if (net != null)
                    {
                        net.Net_personid = netDto.Net_personid;
                        net.Net_nettype = netDto.Net_nettype;
                        net.Net_state = 1;
                    }
                    else
                        originalNets.Add(NewNet(netDto));
                }
            }

            foreach (var phone in originalNets)
                result += await _netRepository.SaveAsync(phone);
            return result;
        }

        #endregion COMMAND'S

        #region METODOS PRIVADO

        private Person GetPerson(PersonDto personDto)
        {
            var person = new Person();

            person.SetID(personDto.Per_DocumentType,
                        personDto.Per_DocumentNumber,
                        personDto.Person_Id,
                        personDto.Per_Ruc);
            person.SetName(personDto.Per_FirstName,
                        personDto.Per_Surname,
                        personDto.Per_SecondSurname,
                        personDto.Per_SecondName);
            person.SetUbigeo(personDto.Per_Address,
                        personDto.Per_UbdisId);
            person.SetInfo(personDto.Per_GenderId,
                        personDto.Per_Birthdate,
                        personDto.Per_secureId,
                        personDto.Per_SecurePolicy);
            person.SetSysInfo(personDto.Per_CreateTime,
                        personDto.Per_EditTime,
                        personDto.Per_CancelTime);
            person.Per_PatientId = personDto.Per_PatientId;
            person.Per_Photo = personDto.Per_Photo;
            return person;
        }

        private PersonDto GetPersonDto(Person person)
        {
            return new PersonDto
            {
                Per_DocumentType = person.PersonId.DocumentType,
                Per_DocumentNumber = person.PersonId.DocumentNumber,
                Per_Ruc = person.PersonId.RUC,
                Per_PatientId = person.Per_PatientId,
                Per_FirstName = person.PersonName.FirstName,
                Per_SecondName = person.PersonName.SecondName,
                Per_Surname = person.PersonName.Surname,
                Per_SecondSurname = person.PersonName.SecondSurname,
                Per_Address = person.PersonUbigeo.Address,
                Per_UbDepId = person.PersonUbigeo.UbDep_Id,
                Per_UbProvId = person.PersonUbigeo.UbProv_Id,
                Per_UbdisId = person.PersonUbigeo.Ubdis_Id,
                Per_GenderId = person.Person_Info.GenderId,
                Per_Birthdate = person.Person_Info.Birthdate,
                Per_CreateTime = person.Person_SysInfo.CreateTime,
                Per_EditTime = person.Person_SysInfo.EditTime,
                Per_CancelTime = person.Person_SysInfo.CancelTime,
                Per_Photo = person.Per_Photo,
                Per_secureId = person.Person_Info.Per_SecureId,
                Per_SecurePolicy = person.Person_Info.Per_SecurePolicy,
                LongName = person.PersonName.LongName(),
                ShortName = person.PersonName.ShortName()
            };
        }

        private Phone NewPhone(PhoneDto phoneDto)
        {
            return new Phone
            {
                Pho_number = phoneDto.Pho_number,
                Pho_personid = phoneDto.Pho_personId,
                Pho_operid = phoneDto.Pho_operatorId,
                Pho_typeuse = phoneDto.Pho_typeId,
                Pho_state = phoneDto.Pho_state
            };
        }

        private Email NewEmail(EmailDto emailDto)
        {
            return new Email
            {
                Email_link = emailDto.Email_link,
                Email_personid = emailDto.Email_personId,
                Email_state = emailDto.Email_state,
                Email_type = emailDto.Email_type
            };
        }

        private Net NewNet(NetDto netDto)
        {
            return new Net
            {
                Net_url = netDto.Net_url,
                Net_personid = netDto.Net_personid,
                Net_nettype = netDto.Net_nettype,
                Net_state = netDto.Net_state
            };
        }

        #endregion METODOS PRIVADO
    }
}