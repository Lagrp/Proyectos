namespace Sgcm.App.DTOs
{
    public class PersonDto
    {
        private string _perDocumentNumber;
        private int _perDocumentType;

        public event EventHandler ValidatedDocumentType;

        //public event EventHandler ValidatedPersonId;

        public string Person_Id { get; private set; }

        public int Per_DocumentType
        {
            get => _perDocumentType;
            set
            {
                if (_perDocumentType != value)
                {
                    _perDocumentType = value;
                    ValidatedDocumentType?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string Per_DocumentNumber
        {
            get => _perDocumentNumber;
            set
            {
                if (_perDocumentNumber != value)
                {
                    _perDocumentNumber = value;
                    CreateId();
                }
            }
        }

        public string Per_PatientId { get; set; }
        public string Per_FirstName { get; set; }
        public string Per_Surname { get; set; }
        public string Per_SecondName { get; set; }
        public string Per_SecondSurname { get; set; }

        public string Per_Ruc { get; set; }
        public string Per_Address { get; set; }
        public int Per_UbdisId { get; set; }
        public int Per_UbProvId { get; init; }
        public int Per_UbDepId { get; init; }
        public int Per_GenderId { get; set; }
        public byte[]? Per_Photo { get; set; }
        public DateTime Per_Birthdate { get; set; }
        public DateTime Per_CreateTime { get; set; }
        public DateTime Per_EditTime { get; set; }
        public DateTime Per_CancelTime { get; set; }
        public int Per_secureId { get; set; }
        public string? Per_SecurePolicy { get; set; }
        public string? LongName { get; set; }
        public string? ShortName { get; set; }

        private void CreateId()
        {
            if (!string.IsNullOrEmpty(Per_DocumentNumber) && Per_DocumentNumber.Length == 8 && Per_DocumentType > 0)
            {
                Person_Id = Per_DocumentType.ToString() + Per_DocumentNumber;
                //ValidatedPersonId?.Invoke(this, EventArgs.Empty);
            }
            else
                Person_Id = null;
        }
    }
}