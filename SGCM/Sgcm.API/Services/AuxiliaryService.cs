namespace Sgcm.App.Services
{
    public class AuxiliaryService
    {
        private IAuxiliaryRepository _axiliaryRepository;

        public AuxiliaryService()
        {
            _axiliaryRepository = new AuxiliaryRepository();
        }

        public async Task<IEnumerable<DocumentTypeDto>> GetTableDocumentTypes()
        {
            var entityVo = await _axiliaryRepository.TableDocumentTypes();
            var entityDto = new List<DocumentTypeDto>();
            foreach (var item in entityVo)
            {
                //tdoc_id, tdoc_name, tdoc_abrev, tdoc_icon
                entityDto.Add(new DocumentTypeDto
                {
                    Tdoc_id = item.Tdoc_id,
                    Tdoc_name = item.Tdoc_name,
                    Tdoc_abrev = item.Tdoc_abrev,
                    Tdoc_icon = item.Tdoc_icon
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<GenderDto>> GetTableGenders()
        {
            var entityVo = await _axiliaryRepository.TableGenders();
            var entityDto = new List<GenderDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new GenderDto
                {
                    Gen_id = item.Gen_id,
                    Gen_type = item.Gen_type
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<DptoDto>> GetTableDepartamentos()
        {
            var entityVo = await _axiliaryRepository.TableDepartamentos();
            var entityDto = new List<DptoDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new DptoDto
                {
                    UbDep_id = item.Ubdep_id,
                    UbDep_nombre = item.Ubdep_name
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<ProvinciaDto>> GetTableProvincias(int iD = 0)
        {
            var entityVo = await _axiliaryRepository.TableProvincias(iD);
            var entityDto = new List<ProvinciaDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new ProvinciaDto
                {
                    UbProv_id = item.Ubprov_id,
                    UbProv_nombre = item.Ubprov_name,
                    UbProv_ubdepid = item.Ubprov_ubdepid
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<ProvinciaDto>> GetTableProvinciasByDptoId(int dptoId)
        {
            var entityVo = await _axiliaryRepository.TableProvincias(dptoId);
            var entityDto = new List<ProvinciaDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new ProvinciaDto
                {
                    UbProv_id = item.Ubprov_id,
                    UbProv_nombre = item.Ubprov_name,
                    UbProv_ubdepid = item.Ubprov_ubdepid
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<UbigeoDto>> GetTableUbigeo(int provId = 0)
        {
            var entityVo = await _axiliaryRepository.TableUbigeo(provId);
            var entityDto = new List<UbigeoDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new UbigeoDto
                {
                    Ubdis_id = item.Ubdis_id,
                    Ubdis_name = item.Ubdis_name,
                    Ubdis_ubdepid = item.Ubdis_ubdepid,
                    Ubdis_ubprovid = item.Ubdis_ubprovid
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<TypeOfUseDto>> GetTableTypeOfUse()
        {
            var entityVo = await _axiliaryRepository.TableTypeOfUse();
            var entityDto = new List<TypeOfUseDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new TypeOfUseDto
                {
                    Type_id = item.Type_id,
                    Type_name = item.Type_name,
                    Type_icon = item.Type_icon
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<PhoneOperatorDto>> GetTablePhoneOperators()
        {
            var entityVo = await _axiliaryRepository.TablePhoneOperators();
            var entityDto = new List<PhoneOperatorDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new PhoneOperatorDto
                {
                    Opet_id = item.Opet_id,
                    Opet_name = item.Opet_name,
                    Opet_logo = item.Opet_logo
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<NetTypesDto>> GetTableNetTypes()
        {
            var entityVo = await _axiliaryRepository.TableNetTypes();
            var entityDto = new List<NetTypesDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new NetTypesDto
                {
                    Nett_id = item.Nett_id,
                    Nett_name = item.Nett_name,
                    Nett_ico = item.Nett_ico,
                    Nett_urlbase = item.Nett_urlbase
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<ProfileTypesDto>> GetTableProfile()
        {
            var entityVo = await _axiliaryRepository.TableProfile();
            var entityDto = new List<ProfileTypesDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new ProfileTypesDto
                {
                    profile_id = item.Profile_id,
                    pro_level = item.Pro_level
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<StateDto>> GetTableStates()
        {
            var entityVo = await _axiliaryRepository.TableStates();
            var entityDto = new List<StateDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new StateDto
                {
                    Est_id = item.Est_id,
                    Est_estado = item.Est_estado,
                });
            }
            return entityDto;
        }

        public async Task<IEnumerable<SecureDto>> GetTableSecures()
        {
            var entityVo = await _axiliaryRepository.TableSecures();
            var entityDto = new List<SecureDto>();
            foreach (var item in entityVo)
            {
                entityDto.Add(new SecureDto
                {
                    Sec_Id = item.Sec_Id,
                    Sec_Name = item.Sec_Name,
                });
            }
            return entityDto;
        }
    }
}