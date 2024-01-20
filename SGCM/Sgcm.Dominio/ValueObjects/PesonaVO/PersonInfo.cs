namespace Sgcm.Dominio.ValueObjects.PesonaVO
{
    public record PersonInfo
    {
        public int GenderId { get; init; }
        public DateTime Birthdate { get; init; }
        public int Per_SecureId { get; set; }

        public string Per_SecurePolicy { get; set; }

        internal PersonInfo(int genderId, DateTime birthdate, int secureId, string securePolicy)
        {
            this.GenderId = genderId;
            this.Birthdate = birthdate;
            this.Per_SecureId = secureId;
            this.Per_SecurePolicy = securePolicy;
        }

        public static PersonInfo Create(int genderId, DateTime birthdate, int secureId, string securePolicy)
        {
            return genderId < 1 || birthdate == null ?
                throw new ArgumentNullException("PersonaInfo: el valor del no debe ser nulo ") :
                new PersonInfo(genderId, birthdate, secureId, securePolicy);
        }
    }
}