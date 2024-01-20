using Sgcm.App.DTOs;
using Sgcm.App.Services;
using Sgcm.InfraSoporte.Autentificacion;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Sgcm.UI.Desktop.VistaModelo
{
    public class ProfileVM : NotifyVM//controller
    {
        #region VARIABLES MIEMBRO

        private ProfileDto _profileUser;
        private AuxiliaryDataVM _auxiliaryData;
        private ProfileService _profileService;
        private PersonService _personService;
        private Visibility _visibleControl;
        private bool _activeControl;
        private bool _editMode;
        private bool _editVisible;
        private PersonPhones _profilePhones;
        private PersonEmails _profileEmails;
        private PersonNets _profileNets;
        private ImageBrush _profilePhoto;

        #endregion VARIABLES MIEMBRO

        #region DEFINICION COMANDOS

        public ICommand EditCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand AddPhoneCommand { get; }
        public ICommand AddEmailCommand { get; }
        public ICommand AddNetCommand { get; }
        public ICommand DeletePhoneCommand { get; }
        public ICommand DeleteEmailCommand { get; }
        public ICommand DeleteNetCommand { get; }
        public ICommand SavePhonesCommand { get; }
        public ICommand SaveEmailsCommand { get; }
        public ICommand SaveNetsCommand { get; }
        public ICommand CancelSavePhonesCommand { get; }
        public ICommand CancelSaveEmailsCommand { get; }
        public ICommand CancelSaveNetsCommand { get; }

        #endregion DEFINICION COMANDOS

        #region CONSTRUCTORES

        public ProfileVM(int userId)
        {
            _auxiliaryData = new AuxiliaryDataVM();
            _profileService = new ProfileService();
            _personService = new PersonService();
            InitializeAsync(userId);
            CancelCommand = new CommandBase(ExecuteCancelCommand);
            EditCommand = new CommandBase(ExecuteEditCommand);
            AddPhoneCommand = new CommandBase(ExecuteAddPhoneCommand);
            AddEmailCommand = new CommandBase(ExecuteAddEmailCommand);
            AddNetCommand = new CommandBase(ExecuteAddNetCommand);
            DeletePhoneCommand = new CommandBase(ExecuteDeletePhoneCommand);
            DeleteEmailCommand = new CommandBase(ExecuteDeleteEmailCommand);
            DeleteNetCommand = new CommandBase(ExecuteDeleteNetCommand);
            SavePhonesCommand = new CommandBase(ExecuteSavePhonesCommand, CanExecuteSavePhonesCommand);
            CancelSavePhonesCommand = new CommandBase(CancelExecuteSavePhonesCommand, CanExecuteSavePhonesCommand);
            SaveEmailsCommand = new CommandBase(ExecuteSaveEmailsCommand, CanExecuteSaveEmailsCommand);
            CancelSaveEmailsCommand = new CommandBase(CancelExecuteSaveEmailsCommand, CanExecuteSaveEmailsCommand);
            SaveNetsCommand = new CommandBase(ExecuteSaveNetsCommand, CanExecuteSaveNetsCommand);
            CancelSaveNetsCommand = new CommandBase(CancelExecuteSaveNetsCommand, CanExecuteSaveNetsCommand);
        }

        public ProfileVM()
        { }

        #endregion CONSTRUCTORES

        #region PROPIEDADES DE LA VISTA

        public ProfileDto ProfileUser
        {
            get => _profileUser;
            set
            {
                _profileUser = value;
                OnPropertyChanged(nameof(ProfileUser));
            }
        }

        public ImageBrush ProfilePhoto
        {
            get => _profilePhoto;
            set
            {
                _profilePhoto = value;
                OnPropertyChanged(nameof(ProfilePhoto));
            }
        }

        public AuxiliaryDataVM AuxiliaryData
        {
            get => _auxiliaryData;
            set
            {
                _auxiliaryData = value;
                OnPropertyChanged(nameof(AuxiliaryData));
            }
        }

        public PersonPhones ProfilePhones
        {
            get => _profilePhones;
            set
            {
                _profilePhones = value;
                OnPropertyChanged(nameof(ProfilePhones));
            }
        }

        public PersonEmails ProfileEmails
        {
            get => _profileEmails;
            set
            {
                _profileEmails = value;
                OnPropertyChanged(nameof(ProfileEmails));
            }
        }

        public PersonNets ProfileNets
        {
            get => _profileNets;
            set
            {
                _profileNets = value;
                OnPropertyChanged(nameof(ProfileNets));
            }
        }

        public bool ActiveControl
        {
            get => _activeControl;
            set
            {
                _activeControl = value;
                OnPropertyChanged(nameof(ActiveControl));
            }
        }

        public Visibility VisibleControl
        {
            get => _visibleControl;
            set
            {
                _visibleControl = value;
                OnPropertyChanged(nameof(VisibleControl));
            }
        }

        public bool EditVisible
        {
            get => _editVisible;
            set
            {
                _editVisible = value;
                OnPropertyChanged(nameof(EditVisible));
            }
        }

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged(nameof(EditMode));
            }
        }

        #endregion PROPIEDADES DE LA VISTA

        #region EXECUTE COMMANDS

        private void ExecuteEditCommand(object obj)
        {
            VisibleControl = Visibility.Visible;
            ActiveControl = true;
            EditVisible = false;
            EditMode = true;
        }

        private void ExecuteCancelCommand(object obj) => InitializeAsync(ActiveUser.UserId);

        #region PHONES COMMAND

        public void ExecuteAddPhoneCommand(object sender)
        {
            var newPhone = new PhoneDto { Pho_personId = ProfileUser.PersonId, Pho_state = 1 };
            if (ProfilePhones == null)
                ProfilePhones = new() { newPhone };
            else
                ProfilePhones.Add(newPhone);
        }

        private void ExecuteDeletePhoneCommand(object obj) => ProfilePhones.Remove((PhoneDto)obj);

        private bool CanExecuteSavePhonesCommand(object obj)
        {
            if (EditMode != true || ProfilePhones == null) return false;
            return true;
        }

        private void ExecuteSavePhonesCommand(object obj)
        {
            Task.Run(async () =>
            {
                try
                {
                    var resultPhones = await _personService.SavePhonesAsync(ProfileUser.PersonId, ProfilePhones);
                    if (resultPhones < 1)
                        MessageBox.Show("Error al Guardar los Telefonos...");
                    else
                        MessageBox.Show("Telefonos Guardados...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadPhones();
            });
        }

        private void CancelExecuteSavePhonesCommand(object obj) => LoadPhones();

        #endregion PHONES COMMAND

        #region EMAILS COMMAND

        public void ExecuteAddEmailCommand(object sender)
        {
            var newEmail = new EmailDto { Email_personId = ProfileUser.PersonId, Email_state = 1 };

            if (ProfileEmails == null)
                ProfileEmails = new() { newEmail };
            else
                ProfileEmails.Add(newEmail);
        }

        private void ExecuteDeleteEmailCommand(object obj) => ProfileEmails.Remove((EmailDto)obj);

        private bool CanExecuteSaveEmailsCommand(object obj)
        {
            if (EditMode != true || ProfileEmails == null) return false;
            return true;
        }

        private void ExecuteSaveEmailsCommand(object obj)
        {
            Task.Run(async () =>
            {
                var resultEmails = await _personService.SaveEmailsAsync(ProfileUser.PersonId, ProfileEmails);
                if (resultEmails < 1)
                    MessageBox.Show("Error al Guardar los Emails...");
                else
                    MessageBox.Show("Email Guardados...");
                LoadEmails();
            });
        }

        private void CancelExecuteSaveEmailsCommand(object obj) => LoadEmails();

        #endregion EMAILS COMMAND

        #region NETS COMMAND

        public void ExecuteAddNetCommand(object sender)
        {
            var newNet = new NetDto { Net_personid = ProfileUser.PersonId, Net_state = 1 };
            if (ProfileNets == null)
                ProfileNets = new() { newNet };
            else
                ProfileNets.Add(newNet);
        }

        private void ExecuteDeleteNetCommand(object obj) => ProfileNets.Remove((NetDto)obj);

        private bool CanExecuteSaveNetsCommand(object obj)
        {
            if (EditMode != true || ProfileNets == null) return false;
            return true;
        }

        private void ExecuteSaveNetsCommand(object obj)
        {
            Task.Run(async () =>
            {
                var resultNets = await _personService.SaveNetsAsync(ProfileUser.PersonId, ProfileNets);
                if (resultNets < 1)
                    MessageBox.Show("Error al Guardar las redes socialea...");
                else
                    MessageBox.Show("Redes Guardadas...");
                LoadNets();
            });
        }

        private void CancelExecuteSaveNetsCommand(object obj) => LoadNets();

        #endregion NETS COMMAND

        #endregion EXECUTE COMMANDS

        #region METODOS PRIVADOS

        private void LoadPhones()
        {
            Task.Run(async () =>
            {
                ProfilePhones = await _personService.GetPhonesHandlerAsync(ProfileUser.PersonId);
            });
        }

        private void LoadEmails()
        {
            Task.Run(async () =>
            {
                ProfileEmails = await _personService.GetEmailsHandlerAsync(ProfileUser.PersonId);
            });
        }

        private void LoadNets()
        {
            Task.Run(async () =>
            {
                ProfileNets = await _personService.GetNetsHandlerAsync(ProfileUser.PersonId);
            });
        }

        private void InitializeAsync(int userId)
        {
            try
            {
                Task.Run(async () =>
                    {
                        ProfileUser = await _profileService.GetProfileUserHandlerAsync(userId);
                    }).GetAwaiter().GetResult();
                ProfilePhoto = ImageTool.LoadImageBrush(imageBytes: ProfileUser.UserPhoto);
                LoadPhones();
                LoadEmails();
                LoadNets();

                VisibleControl = Visibility.Collapsed;
                ActiveControl = false;
                EditVisible = true;
                EditMode = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion METODOS PRIVADOS
    }
}