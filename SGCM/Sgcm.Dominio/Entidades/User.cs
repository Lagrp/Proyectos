using Sgcm.Dominio.ValueObjects.UsuarioVO;

namespace Sgcm.Dominio.Entidades
{
    public class User
    {
        public int User_Id { get; set; }
        public string User_PersonId { get; set; }
        public UserLoginSystem User_LoginSystem { get; set; }
        public UserProfileInfo? User_ProfileInfo { get; private set; }
        public UserSystemInfo? User_SystemInfo { get; private set; }
        public byte[]? User_Photo { get; set; }

        public void GetLoginSystem(string userLogin, int profileId,string password="" )
            => User_LoginSystem = UserLoginSystem.Create(userLogin, profileId, password);

        public void GetProfileInfo(string qualification = "", string colegiatura = "")
            => User_ProfileInfo = UserProfileInfo.Create(qualification, colegiatura);

        public void GetSystemInfo(DateTime createTime, DateTime editTime, int stateId, DateTime cancelTime)
            => User_SystemInfo = UserSystemInfo.Create(createTime, editTime, stateId, cancelTime);
    }
}