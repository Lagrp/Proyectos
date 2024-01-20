namespace Sgcm.Dominio.ValueObjects.UsuarioVO
{
    public record UserProfileInfo
    {
        public string? Specialty { get; init; }
        public string? Colegiatura { get; init; }

        internal UserProfileInfo(string specialty = "", string colegiatura = "")
        {
            this.Colegiatura = colegiatura;
            this.Specialty = specialty;
        }

        public static UserProfileInfo Create(string specialty = "", string colegiatura = "")
        {
            return new UserProfileInfo(specialty, colegiatura);
        }
    }
}