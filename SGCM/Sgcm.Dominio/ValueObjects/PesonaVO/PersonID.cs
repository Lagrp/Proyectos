namespace Sgcm.Dominio.ValueObjects.PesonaVO
{
    public record PersonID
    {
        public string? ID { get; init; }
        public int DocumentType { get; init; }
        public string DocumentNumber { get; init; }
        public string? RUC { get; init; }

        internal PersonID(int documentType, string documentNumber, string? id, string? ruc)
        {
            this.ID = id;
            this.DocumentType = documentType;
            this.DocumentNumber = documentNumber;
            this.RUC = ruc;
        }

        public static PersonID Create(int documentType, string documentNumber, string iD, string ruc)
        {
            string? nId = string.IsNullOrEmpty(iD) ? TriggerID(documentType, documentNumber) : iD;
            return string.IsNullOrEmpty(iD)
                ? throw new ArgumentNullException("PersonID: el valor del ID no debe ser nulo ")
                : new PersonID(documentType, documentNumber, nId, ruc);
        }

        private static string? TriggerID(int documentType, string documentNumber)
        {
            return !string.IsNullOrEmpty(documentNumber) && documentType > 0 ? documentType.ToString() + documentNumber : null;
        }
    }
}