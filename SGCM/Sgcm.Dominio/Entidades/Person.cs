using Sgcm.Dominio.ValueObjects.PesonaVO;

namespace Sgcm.Dominio.Entidades
{
    public class Person
    {
        public PersonID PersonId { get; private set; }
        public Name? PersonName { get; private set; }
        public Ubigeo? PersonUbigeo { get; private set; }
        public PersonInfo? Person_Info { get; private set; }
        public PersonSysInfo? Person_SysInfo { get; private set; }
        public string? Per_PatientId { get; set; }
        public byte[]? Per_Photo { get; set; }

        public void SetID(int documentType, string documentNumber, string iD = "", string ruc = "")
            => PersonId = PersonID.Create(documentType, documentNumber, iD, ruc);

        public void SetName(string firstName, string surname, string secondSurname, string secondName = "")
            => PersonName = Name.Create(firstName, surname, secondSurname, secondName);

        public void SetUbigeo(string address, int ubdis_Id)
            => PersonUbigeo = Ubigeo.Create(address, ubdis_Id);

        public void SetInfo(int genderId, DateTime birthDate, int secureId=1, string securePolicy="")
            => Person_Info = PersonInfo.Create(genderId, birthDate, secureId, securePolicy);

        public void SetSysInfo(DateTime createTime, DateTime editTime, DateTime cancelTime)
            => Person_SysInfo = PersonSysInfo.Create(createTime, editTime, cancelTime);
    }
}