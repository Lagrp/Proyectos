namespace Sgcm.Dominio.ValueObjects.PesonaVO
{
    public record Name
    {
        public string FirstName { get; init; }
        public string? SecondName { get; init; }
        public string Surname { get; init; }
        public string SecondSurname { get; init; }

        internal Name(string firstName, string surname, string secondSurname, string secondName = "")
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Surname = surname;
            this.SecondSurname = secondSurname;
        }

        public static Name Create(string firstName, string surname, string secondSurname, string secondName = "")
        {
            return string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(secondSurname)
                ? throw new ArgumentNullException("Nombre: el valor del no debe ser nulo ")
                : new Name(firstName, surname, secondSurname, secondName);
        }

        public string LongName() => FirstName + " " + SecondName + " " + Surname + " " + SecondSurname;

        public string ShortName() => FirstName + " " + Surname;
    }
}