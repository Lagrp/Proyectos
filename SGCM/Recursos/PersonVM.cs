using MySql.Data.MySqlClient;
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
    public class PersonVM : NotifyVM
    {
        #region VARIABLES MIEMBRO

        private PersonDto _personData;
        private PersonPhones? _phones;
        private PersonEmails? _emails;
        private PersonNets? _nets;
        private ImageBrush? _personPhoto;
        private PersonService _personService;
        private bool _editPersonStatus;
        private EditControlsModeEnum _editPersonUIMode;

        #endregion VARIABLES MIEMBRO

        #region DEFINICION DE COMMANDOS

        public ICommand CancelPersonCommand { get; }
        public ICommand EditPersonCommand { get; }
        public ICommand SaveEditPersonCommand { get; }
        //public ICommand LoadPersonCommand => new CommandBase(ExecuteLoadPersonCommand, CanExecuteLoadPersonCommand);
        public ICommand AddPersonPhoneCommand { get; }
        public ICommand AddPersonEmailCommand { get; }
        public ICommand AddPersonNetCommand { get; }
        public ICommand DeletePersonPhoneCommand { get; }
        public ICommand DeletePersonEmailCommand { get; }
        public ICommand DeletePersonNetCommand { get; }
        public ICommand SavePersonPhonesCommand { get; }
        public ICommand SavePersonEmailsCommand { get; }
        public ICommand SavePersonNetsCommand { get; }
        public ICommand CancelSavePersonPhonesCommand { get; }
        public ICommand CancelSavePersonEmailsCommand { get; }
        public ICommand CancelSavePersonNetsCommand { get; }

        #endregion DEFINICION DE COMMANDOS

        #region DEFINICION DE EVENTOS

        //public delegate void EditPersonUIDelegate();

        //public delegate void LoadPersonDelegate();

        //public event EventHandler EditPersonUIEvent;

        //public event LoadPersonDelegate LoadUserEvent;

        public event EventHandler<EditControlsModeEnum> PersonUIModeEvent;


        #endregion DEFINICION DE EVENTOS

        #region CONTRUCTORES

        public PersonVM()
        {
            _personService = new PersonService();
            InitializePerson();
            //LoadPersonCommand = new CommandBase(ExecuteLoadPersonCommand, CanExecuteLoadPersonCommand);
            //EditPersonCommand = new CommandBase(ExecuteEditPersonCommand, CanExecuteEditPersonCommand);
            //SaveEditPersonCommand = new CommandBase(ExecuteSaveEditPersonCommand, CanExecuteSaveEditPersonCommand);
            CancelPersonCommand = new CommandBase(ExecuteCancelPersonCommand, CanExecuteCancelPersonCommand);
            //AddPersonPhoneCommand = new CommandBase(ExecuteAddPersonPhoneCommand);
            //AddPersonEmailCommand = new CommandBase(ExecuteAddPersonEmailCommand);
            //AddPersonNetCommand = new CommandBase(ExecuteAddPersonNetCommand);
            //DeletePersonPhoneCommand = new CommandBase(ExecuteDeletePersonPhoneCommand);
            //DeletePersonEmailCommand = new CommandBase(ExecuteDeletePersonEmailCommand);
            //DeletePersonNetCommand = new CommandBase(ExecuteDeletePersonNetCommand);
            //EditPersonUIMode = EditPersonControlsModeEnum.InitialState;
            //EditPersonUIEvent?.Invoke();
        }

        #endregion CONTRUCTORES

        #region PROPIEDADES PERSONA

        public PersonDto PersonData
        {
            get => _personData;
            set
            {
                _personData = value;
                OnPropertyChanged(nameof(PersonData));
            }
        }

        public ImageBrush? PersonPhoto
        {
            get => _personPhoto;
            set
            {
                _personPhoto = value;
                OnPropertyChanged(nameof(PersonPhoto));
            }
        }

        public PersonPhones? Phones
        {
            get => _phones;
            set
            {
                _phones = value;
                OnPropertyChanged(nameof(Phones));
            }
        }

        public PersonEmails? Emails
        {
            get => _emails;
            set
            {
                _emails = value;
                OnPropertyChanged(nameof(Emails));
            }
        }

        public PersonNets? Nets
        {
            get => _nets;
            set
            {
                _nets = value;
                OnPropertyChanged(nameof(Nets));
            }
        }

        public bool EditPersonStatus
        {
            get => _editPersonStatus;
            set
            {
                _editPersonStatus = value;
                OnPropertyChanged(nameof(EditPersonStatus));
            }
        }

        //public EditPersonControlsModeEnum EditPersonUIMode
        //{
        //    get => _editPersonUIMode;
        //    set
        //    {
        //        _editPersonUIMode = value;
        //        OnPropertyChanged(nameof(EditPersonUIMode));
        //    }
        //}

        #endregion PROPIEDADES PERSONA

        #region PERSON COMMANDS

        private void ExecuteAddPersonPhoneCommand(object obj)
        {
            var newPhone = new PhoneDto { Pho_personId = PersonData.Person_Id, Pho_state = 1 };
            if (Phones == null)
                Phones = new() { newPhone };
            else
                Phones.Add(newPhone);
        }

        private void ExecuteDeletePersonPhoneCommand(object obj) => Phones.Remove((PhoneDto)obj);

        private void ExecuteAddPersonEmailCommand(object obj)
        {
            var newEmail = new EmailDto { Email_personId = PersonData.Person_Id, Email_state = 1 };

            if (Emails == null)
                Emails = new() { newEmail };
            else
                Emails.Add(newEmail);
        }

        private void ExecuteDeletePersonEmailCommand(object obj) => Emails.Remove((EmailDto)obj);

        private void ExecuteAddPersonNetCommand(object obj)
        {
            var newNet = new NetDto { Net_personid = PersonData.Person_Id, Net_state = 1 };
            if (Nets == null)
                Nets = new() { newNet };
            else
                Nets.Add(newNet);
        }

        private void ExecuteDeletePersonNetCommand(object obj) => Nets.Remove((NetDto)obj);

        private bool CanExecuteLoadPersonCommand(object obj)
        {
            if (PersonData == null)
                return false;
            if (PersonData.Per_DocumentType < 1)
                return false;
            if (PersonData.Per_DocumentNumber.Length != 8)
                return false;
            if (EditPersonStatus)
                return false;
            return true;
        }

        //private void ExecuteLoadPersonCommand(object obj) => LoadPerson();

        private bool CanExecuteCancelPersonCommand(object obj)
        {
            if (PersonData == null)
                return false;
            if (string.IsNullOrEmpty(PersonData.Person_Id))
                return false;
            return true;
        }

        private void ExecuteCancelPersonCommand(object obj) => EditPersonCancel();

        private bool CanExecuteEditPersonCommand(object obj)
        {
            if (PersonData == null)
                return false;
            if (string.IsNullOrEmpty(PersonData.Person_Id))
                return false;
            if (PersonData.Per_DocumentType < 1)
                return false;
            if (PersonData.Per_DocumentNumber.Length != 8)
                return false;
            if (EditPersonStatus)
                return false;
            return true;
        }

        private void ExecuteEditPersonCommand(object obj)
        {
            //EditPersonUIMode = EditPersonControlsModeEnum.EditPerson;
            //EditPersonUIEvent?.Invoke();
        }

        private bool CanExecuteSaveEditPersonCommand(object obj) => PersonValidationsService.PersonValidation(PersonData, Phones, Emails);

        private void ExecuteSaveEditPersonCommand(object obj)
        {
        } //=> SavePerson();

        #endregion PERSON COMMANDS

        #region METODOS PRIVADOS

        private void SavePerson()
        {
            //EditPersonUIMode = EditPersonControlsModeEnum.ValidatedPerson;
            Task.Run(async () =>
            {
                string savedError = "";

                try
                {
                    string errorSavePhones = "";
                    string errorSaveEmails = "";
                    string errorSaveNets = "";

                    PersonData.Per_Photo = ImageTool.ImageToByte(PersonPhoto);
                    var savePerson = await _personService.SavePersonAsync(PersonData);
                    if (savePerson < 1)
                    {
                        savedError = " Persona";
                    }
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

                    savedError = savedError + errorSavePhones + errorSaveEmails + errorSaveNets;
                }
                catch (MySqlException ex)
                {
                    savedError = ex.Message;
                }

                if (string.IsNullOrEmpty(savedError))
                    MessageBox.Show("Datos guardados ...");
                else
                {
                    MessageBox.Show("Error al guardar en ..." + savedError);
                    //EditPersonUIMode = EditPersonControlsModeEnum.InitialState;
                }
            }).GetAwaiter().GetResult();
            //EditPersonUIEvent?.Invoke();
        }

        private void LoadPerson()
        {
            //EditPersonUIMode = EditPersonControlsModeEnum.ValidatedPerson;
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
                        //EditPersonUIMode = EditPersonControlsModeEnum.EditPerson;
                    }
                    else
                    {
                        PersonData.Per_DocumentType = -1;
                        //PersonData.Per_DocumentNumber = "";
                        EditPersonCancel();
                        //EditPersonUIMode = EditPersonControlsModeEnum.InitialState;
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
                    //EditPersonUIMode = EditPersonControlsModeEnum.ValidatedPerson;
                    //LoadUserEvent?.Invoke();
                    PersonUIModeEvent?.Invoke(this, EditControlsModeEnum.Validated);

                }
            }).GetAwaiter().GetResult();
            //EditPersonUIEvent?.Invoke();
        }

        private void EditPersonCancel()
        {
            var docTypebk = PersonData.Per_DocumentType;
            var docNumberbk = PersonData.Per_DocumentNumber;
            PersonData = null;
            Phones = null;
            Emails = null;
            Nets = null;
            InitializePerson();
            if (!string.IsNullOrEmpty(docNumberbk) && docTypebk > 0)
            {
                PersonData.Per_DocumentType = docTypebk;
                //PersonData.Per_DocumentNumber = docNumberbk;
                LoadPerson();
            }
            //EditPersonUIMode = EditPersonControlsModeEnum.InitialState;
            //EditPersonUIEvent?.Invoke();
        }

        private void InitializePerson()
        {
            PersonData = new PersonDto();
            Phones = new();
            Emails = new();
            Nets = new();
            PersonPhoto = ImageTool.LoadImageBrush("/Recursos/Imagenes/usuario1.png", Assembly.GetExecutingAssembly());

        }

        #endregion METODOS PRIVADOS
    }
}