namespace Sgcm.App.Services
{
    public class ProfileService
    {
        private IUserRepository _userRepository;
        private IPersonRepository _personRepository;
        private IAuxiliaryRepository _auxiliaryRepository;

        public ProfileService()
        {
            _userRepository = new UserRepository();
            _personRepository = new PersonRepository();
            _auxiliaryRepository = new AuxiliaryRepository();
        }

        #region QUERYS HANDLERS

        public async Task<ProfileDto> GetProfileUserHandlerAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId.ToString());
            var person = await _personRepository.GetByIdAsync(user.User_PersonId);
            var _DocumentType = _auxiliaryRepository.TableDocumentTypes(person.PersonId.DocumentType);
            var _Gender = _auxiliaryRepository.TableGenders(person.Person_Info.GenderId);
            var _dpto = _auxiliaryRepository.TableDepartamentos();
            var _prov = _auxiliaryRepository.TableProvincias(person.PersonUbigeo.UbDep_Id);
            var _ubigeo = _auxiliaryRepository.TableUbigeo(person.PersonUbigeo.UbProv_Id);
            var _profile = _auxiliaryRepository.TableProfile(user.User_LoginSystem.ProfileId);
            var _state = _auxiliaryRepository.TableStates(user.User_SystemInfo.StateId);
            await Task.WhenAll(_DocumentType, _Gender, _dpto, _prov, _ubigeo, _profile, _state);

            return new ProfileDto
            {
                PersonId = person.PersonId.ID,
                LongName = person.PersonName.LongName(),
                DocumentType = _DocumentType.Result.First().Tdoc_abrev,
                DocumentNumber = person.PersonId.DocumentNumber,
                DocumentIco = _DocumentType.Result.First().Tdoc_icon,
                Ruc = person.PersonId.RUC,
                BirthDate = person.Person_Info.Birthdate.ToString("dd/MM/yyyy"),
                Gender = _Gender.Result.First().Gen_type,
                Departamento = _dpto.Result.First().Ubdep_name,
                Provincia = _prov.Result.First().Ubprov_name,
                Distrito = _ubigeo.Result.First().Ubdis_name,
                Address = person.PersonUbigeo.Address,
                Specialty = user.User_ProfileInfo.Specialty,
                Colegiatura = user.User_ProfileInfo.Colegiatura,
                UserLogin = user.User_LoginSystem.UserLogin,
                Password = user.User_LoginSystem.Password,
                UserProfile = _profile.Result.First().Pro_level,
                UserCreateTime = user.User_SystemInfo.CreateTime.ToString("dd/MM/yyyy"),
                UserEditTime = user.User_SystemInfo.EditTime.ToString("dd/MM/yyyy"),
                UserCancelTime = user.User_SystemInfo.CancelTime.ToString(),
                UserPhoto = person.Per_Photo,
                UserState = _state.Result.First().Est_estado
              
            };
        }

        #endregion QUERYS HANDLERS
    }
}