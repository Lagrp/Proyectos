namespace Sgcm.App.DTOs
{
    public class ProfileDto
    {
        public string PersonId { get; set; }
        public string LongName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentIco { get; set; }
        public string DocumentNumber { get; set; }
        public string? Ruc { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; init; }
        public string Distrito { get; init; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public string Colegiatura { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string UserProfile { get; set; }
        public byte[]? UserPhoto { get; set; }
        public string UserCreateTime { get; set; }
        public string UserEditTime { get; set; }
        public string? UserCancelTime { get; set; }
        public string UserState { get; set; }
    }
}