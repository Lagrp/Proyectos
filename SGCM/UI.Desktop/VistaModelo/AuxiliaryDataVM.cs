using Sgcm.App.DTOs.AuxiliaryDto;
using Sgcm.App.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sgcm.UI.Desktop.VistaModelo
{
    public class AuxiliaryDataVM : NotifyVM
    {
        #region VARIABLES MIEMBRO

        private AuxiliaryService _auxiliaryService;
        private IEnumerable<DocumentTypeDto> _getDocumentTypes;
        private IEnumerable<GenderDto> _getGenders;
        private IEnumerable<DptoDto> _getDepartamentos;
        private IEnumerable<ProvinciaDto> _getProvincias;
        private IEnumerable<UbigeoDto> _getDistritos;
        private IEnumerable<TypeOfUseDto> _getPhoneTypes;
        private IEnumerable<PhoneOperatorDto> _getPhoneOperator;
        private IEnumerable<TypeOfUseDto> _getEmailTypes;
        private IEnumerable<ProfileTypesDto> _getProfile;
        private IEnumerable<StateDto> _getStates;
        private IEnumerable<NetTypesDto> _getNetTypes;
        private IEnumerable<SecureDto> _getSecure;

        #endregion VARIABLES MIEMBRO

        public AuxiliaryDataVM()
        {
            _auxiliaryService = new AuxiliaryService();
            InitializeAsync();
        }

        private void InitializeAsync()
        {
            Task.Run(async () =>
            {
                var _documentTypes = _auxiliaryService.GetTableDocumentTypes();
                var _genders = _auxiliaryService.GetTableGenders();
                var _departamentos = _auxiliaryService.GetTableDepartamentos();
                var _provincias = _auxiliaryService.GetTableProvincias();
                var _distritos = _auxiliaryService.GetTableUbigeo();
                var _phoneTypes = _auxiliaryService.GetTableTypeOfUse();
                var _phoneOperator = _auxiliaryService.GetTablePhoneOperators();
                var _emailTypes = _auxiliaryService.GetTableTypeOfUse();
                var _profileTypes = _auxiliaryService.GetTableProfile();
                var _netTypes = _auxiliaryService.GetTableNetTypes();
                var _states = _auxiliaryService.GetTableStates();
                var _secure = _auxiliaryService.GetTableSecures();

                await Task.WhenAll(_documentTypes, _genders, _departamentos, _provincias, _distritos,
                                   _phoneTypes, _phoneOperator, _emailTypes, _netTypes, _profileTypes, _states, _secure);

                GetDocumentTypes = _documentTypes.Result;
                GetGenders = _genders.Result;
                GetDepartamentos = _departamentos.Result;
                GetProvincias = _provincias.Result;
                GetDistritos = _distritos.Result;
                GetPhoneTypes = _phoneTypes.Result;
                GetPhoneOperator = _phoneOperator.Result;
                GetEmailTypes = _emailTypes.Result;
                GetNetTypes = _netTypes.Result;
                GetProfile = _profileTypes.Result;
                GetStates = _states.Result;
                GetSecures=_secure.Result;
            }).GetAwaiter().GetResult();
        }

        #region AUXILIARES PERSONA

        public IEnumerable<DocumentTypeDto> GetDocumentTypes
        {
            get => _getDocumentTypes;
            private set
            {
                _getDocumentTypes = value;
                OnPropertyChanged(nameof(GetDocumentTypes));
            }
        }

        public IEnumerable<GenderDto> GetGenders
        {
            get => _getGenders;
            private set
            {
                _getGenders = value;
                OnPropertyChanged(nameof(GetGenders));
            }
        }

        public IEnumerable<DptoDto> GetDepartamentos
        {
            get => _getDepartamentos;
            private set
            {
                _getDepartamentos = value;
                OnPropertyChanged(nameof(GetDepartamentos));
            }
        }

        public IEnumerable<ProvinciaDto> GetProvincias
        {
            get => _getProvincias;
            set
            {
                _getProvincias = value;
                OnPropertyChanged(nameof(_getProvincias));
            }
        }

        public IEnumerable<UbigeoDto> GetDistritos
        {
            get => _getDistritos;
            set
            {
                _getDistritos = value;
                OnPropertyChanged(nameof(GetDistritos));
            }
        }

        public async Task<IEnumerable<ProvinciaDto>> GetProvinciasByDptoId(int dptoId) => await _auxiliaryService.GetTableProvinciasByDptoId(dptoId);

        public async Task<IEnumerable<UbigeoDto>> GetUbigeoByProvId(int provId) => await _auxiliaryService.GetTableUbigeo(provId);

        public IEnumerable<TypeOfUseDto> GetPhoneTypes
        {
            get => _getPhoneTypes;
            private set
            {
                _getPhoneTypes = value;
                OnPropertyChanged(nameof(GetPhoneTypes));
            }
        }

        public IEnumerable<PhoneOperatorDto> GetPhoneOperator
        {
            get => _getPhoneOperator;
            private set
            {
                _getPhoneOperator = value;
                OnPropertyChanged(nameof(GetPhoneOperator));
            }
        }

        public IEnumerable<TypeOfUseDto> GetEmailTypes
        {
            get => _getEmailTypes;
            private set
            {
                _getEmailTypes = value;
                OnPropertyChanged(nameof(GetEmailTypes));
            }
        }

        public IEnumerable<NetTypesDto> GetNetTypes
        {
            get => _getNetTypes;
            private set
            {
                _getNetTypes = value;
                OnPropertyChanged(nameof(GetNetTypes));
            }
        }

        public IEnumerable<SecureDto> GetSecures
        {
            get => _getSecure;
            set
            {
                _getSecure = value;
                OnPropertyChanged(nameof(GetSecures));
            }

        }

        #endregion AUXILIARES PERSONA

        #region AUXILIARES USUARIO

        public IEnumerable<ProfileTypesDto> GetProfile
        {
            get => _getProfile;
            private set
            {
                _getProfile = value;
                OnPropertyChanged(nameof(GetProfile));
            }
        }

        public IEnumerable<StateDto> GetStates
        {
            get => _getStates;
            private set
            {
                _getStates = value;
                OnPropertyChanged(nameof(GetStates));
            }
        }

        #endregion AUXILIARES USUARIO
    }
}