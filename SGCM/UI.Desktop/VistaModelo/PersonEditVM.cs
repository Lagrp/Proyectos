using Sgcm.App.DTOs;
using Sgcm.App.Services;
using Sgcm.App.Validations;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Sgcm.UI.Desktop.VistaModelo
{
    internal class PersonEditVM : NotifyVM
    {
        #region VARIABLES MIEMBRO

        private PersonDto _personData;
        private UserDto _userData;
        private PatientDto _patient;
        private PersonPhones? _phones;
        private PersonEmails? _emails;
        private PersonNets? _nets;
        private ImageBrush? _personPhoto;
        private AuxiliaryDataVM _auxiliaryData;
        private PersonService _personService;
        private PatientService _patientService;
        private UserService _userService;
        private bool _activationUIPersonControls;
        private bool _activationUIUserControls;
        private bool _documentNumberActivation;
        private bool _documentTypeActivation;
        private Visibility _visibilityPersonEditingControls;
        private Visibility _visibilityUserEditingControls = Visibility.Collapsed;
        private Visibility _linkVisibleEditMode;
        private bool _activeSearchButton;
        private bool _activeEditMode;
        private EditUIModeEnum _editUIMode;
        private int _activeTabIndex;

        #endregion VARIABLES MIEMBRO

        #region UI COMMANDOS

        public ICommand LoadCommand => new CommandBase(ExecuteLoadCommand, CanExecuteLoadCommand);
        public ICommand EditCommand => new CommandBase(ExecuteEditCommand, CanExecuteEditCommand);
        public ICommand SaveEditCommand => new CommandBase(ExecuteSaveEditCommand, CanExecuteSaveEditCommand);
        public ICommand CancelEditCommand => new CommandBase(ExecuteCancelEditCommand, CanExecuteCancelEditCommand);
        public ICommand CancelAllCommand => new CommandBase(ExecuteCancelAllCommand, CanExecuteCancelAllCommand);
        public ICommand AddPersonPhoneCommand => new CommandBase(ExecuteAddPersonPhoneCommand);
        public ICommand AddPersonEmailCommand => new CommandBase(ExecuteAddPersonEmailCommand);
        public ICommand AddPersonNetCommand => new CommandBase(ExecuteAddPersonNetCommand);
        public ICommand DeletePersonPhoneCommand => new CommandBase(ExecuteDeletePersonPhoneCommand);
        public ICommand DeletePersonEmailCommand => new CommandBase(ExecuteDeletePersonEmailCommand);
        public ICommand DeletePersonNetCommand => new CommandBase(ExecuteDeletePersonNetCommand);

        #endregion UI COMMANDOS

        #region CONTRUCTORES

        public PersonEditVM(EditUIModeEnum editUIMode)
        {
            _editUIMode = editUIMode;
            _auxiliaryData = new AuxiliaryDataVM();
            _personService = new PersonService();

            InitializeView(_editUIMode);
        }

        public PersonEditVM()
        {
        }

        #endregion CONTRUCTORES

        #region PROPIEDADES PERSONA/USUARIO/PASIENTE

        public PersonDto PersonData
        {
            get => _personData;
            set
            {
                if (_personData != value)
                {
                    _personData = value;
                    OnPropertyChanged(nameof(PersonData));
                }
            }
        }

        public UserDto UserData
        {
            get => _userData;
            set
            {
                //if (_userData != value)
                //{
                _userData = value;
                OnPropertyChanged(nameof(UserData));
                //}
            }
        }

        public ImageBrush? PersonPhoto
        {
            get => _personPhoto;
            set
            {
                if (_personPhoto != value)
                {
                    _personPhoto = value;
                    OnPropertyChanged(nameof(PersonPhoto));
                }
            }
        }

        public PersonPhones? Phones
        {
            get => _phones;
            set
            {
                if (_phones != value)
                {
                    _phones = value;
                    OnPropertyChanged(nameof(Phones));
                }
            }
        }

        public PersonEmails? Emails
        {
            get => _emails;
            set
            {
                if (_emails != value)
                {
                    _emails = value;
                    OnPropertyChanged(nameof(Emails));
                }
            }
        }

        public PersonNets? Nets
        {
            get => _nets;
            set
            {
                if (_nets != value)
                {
                    _nets = value;
                    OnPropertyChanged(nameof(Nets));
                }
            }
        }

        #endregion PROPIEDADES PERSONA/USUARIO/PASIENTE

        #region PROPIEDADES UI

        public AuxiliaryDataVM AuxiliaryData
        {
            get => _auxiliaryData;
            set
            {
                if (_auxiliaryData != value)
                {
                    _auxiliaryData = value;
                    OnPropertyChanged(nameof(AuxiliaryData));
                }
            }
        }

        public bool ActivationUIPersonControls
        {
            get => _activationUIPersonControls;
            set
            {
                if (_activationUIPersonControls != value)
                {
                    _activationUIPersonControls = value;
                    OnPropertyChanged(nameof(ActivationUIPersonControls));
                }
            }
        }

        public bool ActivationUIUserControls
        {
            get => _activationUIUserControls;
            set
            {
                if (_activationUIUserControls != value)
                {
                    _activationUIUserControls = value;
                    OnPropertyChanged(nameof(ActivationUIUserControls));
                }
            }
        }

        public bool DocumentNumberActivation
        {
            get => _documentNumberActivation;
            set
            {
                if (_documentNumberActivation != value)
                {
                    _documentNumberActivation = value;
                    OnPropertyChanged(nameof(DocumentNumberActivation));
                }
            }
        }

        public bool DocumentTypeActivation
        {
            get => _documentTypeActivation;
            set
            {
                if (_documentTypeActivation != value)
                {
                    _documentTypeActivation = value;
                    OnPropertyChanged(nameof(DocumentTypeActivation));
                }
            }
        }

        public Visibility LinkVisibleEditMode
        {
            get => _linkVisibleEditMode;
            set
            {
                if (_linkVisibleEditMode != value)
                {
                    _linkVisibleEditMode = value;
                    OnPropertyChanged(nameof(LinkVisibleEditMode));
                }
            }
        }

        public Visibility VisibilityPersonEditingControls
        {
            get => _visibilityPersonEditingControls;
            set
            {
                if (_visibilityPersonEditingControls != value)
                {
                    _visibilityPersonEditingControls = value;
                    OnPropertyChanged(nameof(VisibilityPersonEditingControls));
                }
            }
        }

        public Visibility VisibilityUserEditingControls
        {
            get => _visibilityUserEditingControls;
            set
            {
                if (_visibilityUserEditingControls != value)
                {
                    _visibilityUserEditingControls = value;
                    OnPropertyChanged(nameof(VisibilityUserEditingControls));
                }
            }
        }

        public int ActiveTabIndex
        {
            get => _activeTabIndex;
            set
            {
                if (_activeTabIndex != value)
                {
                    _activeTabIndex = value;
                    OnPropertyChanged(nameof(ActiveTabIndex));
                }
            }
        }

        #endregion PROPIEDADES UI

        #region EXECUTE UI COMMANDS

        private void ExecuteLoadCommand(object obj) => Load();

        private bool CanExecuteLoadCommand(object obj)
        {
            if (PersonData == null)
                return false;
            if (PersonData.Per_DocumentType < 1)
                return false;
            if (PersonData.Per_DocumentNumber.Length != 8)
                return false;
            if (_activeSearchButton == false)
                return false;
            return true;
        }

        private void ExecuteEditCommand(object obj) => EditControlsMode(EditControlsModeEnum.Edited);

        private bool CanExecuteEditCommand(object obj)
        {
            if (_activeEditMode)
                return false;
            if (PersonData == null)
                return false;
            if (string.IsNullOrEmpty(PersonData.Person_Id))
                return false;
            if (PersonData.Per_DocumentType < 1)
                return false;
            if (PersonData.Per_DocumentNumber.Length != 8)
                return false;
            return true;
        }

        private void ExecuteSaveEditCommand(object obj) => Save();

        private bool CanExecuteSaveEditCommand(object obj)
        {
            if (_activeEditMode)
            {
                return PersonValidationsService.PersonValidation(PersonData, Phones, Emails);
            }
            return false;
        }

        private void ExecuteCancelEditCommand(object obj) => EditPersonCancel();

        private bool CanExecuteCancelEditCommand(object obj)
        {
            if (_activeEditMode == false)
                return false;
            if (PersonData == null)
                return false;
            if (string.IsNullOrEmpty(PersonData.Person_Id))
                return false;
            return true;
        }

        private void ExecuteCancelAllCommand(object obj)
        {
            PersonData = null;
            UserData = null;
            InitializeView(_editUIMode);
        }

        private bool CanExecuteCancelAllCommand(object obj)
        {
            //if (PersonData == null)
            //    return false;
            //if (string.IsNullOrEmpty(PersonData.Person_Id))
            //    return false;
            return true;
        }

        private void ExecuteAddPersonPhoneCommand(object obj)
        {
            var newPhone = new PhoneDto { Pho_personId = PersonData.Person_Id, Pho_state = 1 };
            if (Phones == null)
                Phones = [newPhone];
            else
                Phones.Add(newPhone);
        }

        private void ExecuteDeletePersonPhoneCommand(object obj) => Phones.Remove((PhoneDto)obj);

        private void ExecuteAddPersonEmailCommand(object obj)
        {
            var newEmail = new EmailDto { Email_personId = PersonData.Person_Id, Email_state = 1 };

            if (Emails == null)
                Emails = [newEmail];
            else
                Emails.Add(newEmail);
        }

        private void ExecuteDeletePersonEmailCommand(object obj) => Emails.Remove((EmailDto)obj);

        private void ExecuteAddPersonNetCommand(object obj)
        {
            var newNet = new NetDto { Net_personid = PersonData.Person_Id, Net_state = 1 };
            if (Nets == null)
                Nets = [newNet];
            else
                Nets.Add(newNet);
        }

        private void ExecuteDeletePersonNetCommand(object obj) => Nets.Remove((NetDto)obj);

        #endregion EXECUTE UI COMMANDS

        #region METODOS PRIVADOS

        private void InitializeView(EditUIModeEnum editUIMode)
        {
            PersonData = new PersonDto();
            Phones = new();
            Emails = new();
            Nets = new();
            PersonPhoto = ImageTool.LoadImageBrush("/Recursos/Imagenes/usuario1.png", Assembly.GetExecutingAssembly());
            PersonData.ValidatedDocumentType += PersonData_ValidatedDocumentType;

            if (editUIMode == EditUIModeEnum.Usuario)
            {
                _userService = new UserService();
                UserData = new UserDto();
                VisibilityUserEditingControls = Visibility.Visible;
            }
            else
            {
                _patient = new PatientDto();
                VisibilityUserEditingControls = Visibility.Collapsed;
            }

            EditControlsMode(EditControlsModeEnum.InitialState);
        }
        private void PersonData_ValidatedDocumentType(object? sender, EventArgs e)
        {
            EditControlsMode(EditControlsModeEnum.Searching);
        }

        private void Load()
        {
            Task.Run(async () =>
            {
                var validPerson = await _personService.GetPersonHandlerAsync(PersonData.Person_Id);

                if (validPerson == null)
                {
                    var result = MessageBox.Show("Persona no registrada ¿desea registrarla?",
                            "SGCM", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        PersonData.Per_CreateTime = DateTime.Now;
                        EditControlsMode(EditControlsModeEnum.Edited);
                    }
                    else
                    {
                        PersonData.Per_DocumentType = -1;
                        PersonData.Per_DocumentNumber = "";
                        EditPersonCancel();
                    }
                }
                else
                {
                    PersonData = validPerson;
                    if (PersonData.Per_Photo != null)
                        PersonPhoto = ImageTool.LoadImageBrush(imageBytes: PersonData.Per_Photo);
                    var phones = _personService.GetPhonesHandlerAsync(PersonData.Person_Id);
                    var emails = _personService.GetEmailsHandlerAsync(PersonData.Person_Id);
                    var nets = _personService.GetNetsHandlerAsync(PersonData.Person_Id);

                    await Task.WhenAll(phones, emails, nets);

                    Phones = phones.Result;
                    Emails = emails.Result;
                    Nets = nets.Result;

                    if (_editUIMode == EditUIModeEnum.Usuario)
                        UserData = await _userService.GetUserByPersonId(PersonData.Person_Id);
                    else
                    {
                        if (string.IsNullOrEmpty(PersonData.Per_PatientId))
                        {
                            var unregistered = MessageBox.Show("Paciente no registrado, desea registrarlo", "Paciente no Registrado", MessageBoxButton.YesNo);
                            if (unregistered == MessageBoxResult.Yes)
                                Save();
                        }
                    }
                    EditControlsMode(EditControlsModeEnum.Validated);
                }
            }).GetAwaiter().GetResult();
        }

        private void Save()
        {
            Task.Run(async () =>
            {
                string savedError = "";

                //try
                //{
                string errorSavePatient = "";
                string errorSavePhones = "";
                string errorSaveEmails = "";
                string errorSaveNets = "";
                string errorSaveUser = "";

                PersonData.Per_Photo = ImageTool.ImageToByte(PersonPhoto);
                if (string.IsNullOrEmpty(PersonData.Per_PatientId))
                    PersonData.Per_PatientId = "P" + PersonData.Person_Id;



                var savePerson = await _personService.SavePersonAsync(PersonData);
                if (savePerson < 1)
                {
                    savedError = " Persona";
                }
                else
                {
                    if (Phones != null && Phones.Count > 0)
                    {
                        var savePhones = await _personService.SavePhonesAsync(PersonData.Person_Id, Phones);
                        errorSavePhones = savePhones < 1 ? "/Telefonos" : "";
                    }
                    if (Emails != null && Emails.Count > 0)
                    {
                        var saveEmails = await _personService.SaveEmailsAsync(PersonData.Person_Id, Emails);
                        errorSavePhones = saveEmails < 1 ? "/Emails" : "";
                    }
                    if (Nets != null && Nets.Count > 0)
                    {
                        var saveNets = await _personService.SaveNetsAsync(PersonData.Person_Id, Nets);
                        errorSaveNets = saveNets < 1 ? "/Redes" : "";
                    }
                    if (_editUIMode == EditUIModeEnum.Paciente)
                    {
                        _patient.Patient_id = PersonData.Per_PatientId;
                        _patient.Pac_person = PersonData;
                        _patient.Pac_state = 1;
                        var savePatient = await new PatientService().SavePatientAsync(_patient);
                        errorSavePatient = savePatient < 1 ? "/Paciente" : "";
                    }
                    else
                    {
                        UserData.User_CreateTime = UserData.User_Id == 0 ? DateTime.Now.Date.ToString() : UserData.User_CreateTime;
                        UserData.User_Password = UserData.User_Id == 0 ? "1234" : UserData.User_Password;
                        var saveUser = await _userService.SaveUserAsync(UserData);
                        errorSaveUser = saveUser < 1 ? "/Usuarios" : "";
                    }

                }

                savedError = savedError + errorSavePhones + errorSaveEmails + errorSaveNets + errorSaveUser;
                //}
                //catch (Exception ex)
                //{
                //    savedError = ex.Message;
                //}

                if (string.IsNullOrEmpty(savedError))
                {
                    MessageBox.Show("Datos guardados ...");
                }
                else
                {
                    MessageBox.Show("Error al guardar en ..." + savedError);
                }
                EditControlsMode(EditControlsModeEnum.Validated);
            }).GetAwaiter().GetResult();
        }

        private void EditPersonCancel()
        {
            var docTypebk = PersonData.Per_DocumentType;
            var docNumberbk = PersonData.Per_DocumentNumber;
            PersonData = null;
            UserData = null;
            _patient = null;
            Phones = null;
            Emails = null;
            Nets = null;
            InitializeView(_editUIMode);
            if (!string.IsNullOrEmpty(docNumberbk) && docTypebk > 0)
            {
                PersonData.Per_DocumentType = docTypebk;
                PersonData.Per_DocumentNumber = docNumberbk;
                Load();
            }
        }

        private void EditControlsMode(EditControlsModeEnum mode)
        {
            switch (mode)
            {
                case EditControlsModeEnum.InitialState:
                    DocumentTypeActivation = true;
                    DocumentNumberActivation = false;
                    ActivationUIPersonControls = false;
                    VisibilityPersonEditingControls = Visibility.Collapsed;
                    LinkVisibleEditMode = Visibility.Visible;
                    _activeSearchButton = false;
                    _activeEditMode = false;
                    ActiveTabIndex = 0;
                    break;

                case EditControlsModeEnum.Edited:
                    DocumentTypeActivation = false;
                    DocumentNumberActivation = false;
                    ActivationUIPersonControls = true;
                    VisibilityPersonEditingControls = Visibility.Visible;
                    LinkVisibleEditMode = Visibility.Collapsed;
                    _activeSearchButton = false;
                    _activeEditMode = true;
                    break;

                case EditControlsModeEnum.Validated:
                    DocumentTypeActivation = false;
                    DocumentNumberActivation = false;
                    ActivationUIPersonControls = false;
                    VisibilityPersonEditingControls = Visibility.Collapsed;
                    LinkVisibleEditMode = Visibility.Visible;
                    _activeSearchButton = false;
                    _activeEditMode = false;
                    ActiveTabIndex = 0;
                    break;

                case EditControlsModeEnum.Searching:
                    DocumentTypeActivation = false;
                    DocumentNumberActivation = true;
                    _activeSearchButton = true;
                    _activeEditMode = false;
                    break;
            }
        }

        #endregion METODOS PRIVADOS
    }
}