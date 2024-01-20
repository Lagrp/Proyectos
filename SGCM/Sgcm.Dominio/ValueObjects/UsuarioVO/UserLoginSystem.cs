namespace Sgcm.Dominio.ValueObjects.UsuarioVO
{
    public record UserLoginSystem
    {
        public string UserLogin { get; init; }
        public string? Password { get; init; }
        public int ProfileId { get; init; }
        internal UserLoginSystem(string userLogin,int profileId, string password )
        {
            this.UserLogin = userLogin;
            this.ProfileId = profileId;
            if(!string.IsNullOrEmpty(password) )
                this.Password = password;
        }
        public static UserLoginSystem Create(string userLogin, int profileId, string password = "")
        {
            return string.IsNullOrEmpty(userLogin) || profileId < 1 ?
                throw new ArgumentNullException("SystemInfo: el valor del no debe ser nulo ") :
                new UserLoginSystem(userLogin, profileId, password);
        }
    }
}