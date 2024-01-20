using Sgcm.Dominio.ValueObjects.AuxiliaryVO;

namespace Sgcm.Dominio.Interfaces
{
    public interface IAuxiliaryRepository
    {
        Task<IEnumerable<DocumentTypeVo>> TableDocumentTypes(int Id = 0);

        Task<IEnumerable<GenderVo>> TableGenders(int Id = 0);

        Task<IEnumerable<DptoVo>> TableDepartamentos(int Id = 0);

        Task<IEnumerable<ProvinciaVo>> TableProvincias(int dptoId = 0);

        //Task<IEnumerable<ProvinciaVo>> TableProvinciasByDptoId(int dptoId);

        Task<IEnumerable<UbigeoVo>> TableUbigeo(int ProvId = 0);

        //Task<IEnumerable<UbigeoVo>> TableUbigeoByProvId(int provId);

        Task<IEnumerable<StateVo>> TableStates(int Id = 0);

        Task<IEnumerable<ProfileVo>> TableProfile(int Id = 0);

        Task<IEnumerable<TypeOfUseVo>> TableTypeOfUse(int Id = 0);

        Task<IEnumerable<PhoneOperatorVo>> TablePhoneOperators(int Id = 0);

        //Task<IEnumerable<EmailTypesVo>> TableEmailTypes(int Id = 0);

        Task<IEnumerable<NetTypesVo>> TableNetTypes(int Id = 0);

        Task<IEnumerable<SecureVo>> TableSecures();
    }
}