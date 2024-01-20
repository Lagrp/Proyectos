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
    public class UserVM : NotifyVM
    {
        #region VARIABLES MIEMBRO

        private UserDto? _userData;
        private UserService _userService;
        private ImageBrush? _userPhoto;
        private EditControlsModeEnum _editUserUIMode;

        #endregion VARIABLES MIEMBRO

        #region DEFINICION DE EVENTOS

        public delegate void EditUserUIDelegate();

        public event EditUserUIDelegate EditUserUIEvent;

        #endregion DEFINICION DE EVENTOS

        #region DEFINICION DE COMANDOS

        public ICommand RegisterUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand CancelEditUserCommand { get; }

        #endregion DEFINICION DE COMANDOS

        #region CONSTRUCTORES

        public UserVM()
        {
            _userService = new UserService();
            InitializeUser();
            EditUserCommand = new CommandBase(ExecuteEditUserCommand, CanEditUserCommand);
            RegisterUserCommand = new CommandBase(ExecuteRegisterUserCommand, CanExecuteRegisterUserCommand);
            CancelEditUserCommand = new CommandBase(ExecuteCancelEditUserCommand, CanExecuteCancelEditUserCommand);
        }

        #endregion CONSTRUCTORES

        #region PROPIEDADES USUARIO

        public UserDto? UserData
        {
            get => _userData;
            set
            {
                _userData = value;
                OnPropertyChanged(nameof(UserData));
            }
        }

        public ImageBrush? UserPhoto
        {
            get => _userPhoto;
            set
            {
                _userPhoto = value;
                OnPropertyChanged(nameof(UserPhoto));
            }
        }

        //public EditUserControlsModeEnum EditUserUIMode
        //{
        //    get => _editUserUIMode;
        //    set
        //    {
        //        _editUserUIMode = value;
        //        OnPropertyChanged(nameof(EditUserUIMode));
        //    }
        //}

        #endregion PROPIEDADES USUARIO

        #region USER COMMANDS

        private bool CanExecuteRegisterUserCommand(object obj) => UserValidationsService.UseValidation(UserData);

        private void ExecuteRegisterUserCommand(object obj) => SaveUser();

        private bool CanEditUserCommand(object obj)
        {
            if (UserData == null)
                return false;
            if (UserData.User_Id < 1)
                return false;

            return true;
        }

        private void ExecuteEditUserCommand(object obj)
        {
            //EditUserUIMode = EditControlsModeEnum.EditUser;
            //EditUserUIEvent?.Invoke();
        }

        private bool CanExecuteCancelEditUserCommand(object obj)
        {
            //if (UserData == null)
            //    return false;
            //if (EditUserUIMode != EditControlsModeEnum.EditUser)
            //    return false;
            return true;
        }

        private void ExecuteCancelEditUserCommand(object obj) => CancelEditUser();

        #endregion USER COMMANDS

        #region METODOS PUBLICOS

        public void LoadUserByPersonId(string personid)
        {
            Task.Run(async () =>
            {
                var userTmp = await _userService.GetUserByPersonId(personid);

                if (userTmp != null)
                {
                    UserData = userTmp;
                    UserPhoto = ImageTool.LoadImageBrush(imageBytes: UserData.User_Photo);
                    //EditUserUIMode = EditUserControlsModeEnum.InitialState;
                }
                else
                {
                    UserData.User_Id = 0;
                    UserData.User_PersonId = personid;
                    //EditUserUIMode = EditUserControlsModeEnum.EditUser;
                }
            }).GetAwaiter().GetResult();
            EditUserUIEvent?.Invoke();
        }

        #endregion METODOS PUBLICOS

        #region METODOS PRIVADOS

        private void InitializeUser()
        {
            UserData = new();
            UserPhoto = ImageTool.LoadImageBrush("/Recursos/Imagenes/usuario1.png", Assembly.GetExecutingAssembly());
        }

        private void CancelEditUser()
        {
            var personIdTemp = UserData.User_PersonId;
            UserData = null;
            InitializeUser();
            if (!string.IsNullOrEmpty(personIdTemp))
            {
                LoadUserByPersonId(personIdTemp);
            }

            //EditUserUIMode = EditUserControlsModeEnum.InitialState;
            EditUserUIEvent?.Invoke();
        }

        private void SaveUser()
        {
            UserData.User_Photo = ImageTool.ImageToByte(UserPhoto);
            UserData.User_CreateTime = UserData.User_Id == 0 ? DateTime.Now.Date.ToString() : UserData.User_CreateTime;
            UserData.User_Password = UserData.User_Id == 0 ? "1234" : UserData.User_Password;
            Task.Run(async () =>
            {
                try
                {
                    var result = await _userService.SaveUserAsync(UserData);
                    if (result > 0)
                        MessageBox.Show("Datos guardados ...");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar en ..." + ex.Message);
                }
                CancelEditUser();
            }).GetAwaiter().GetResult();
        }

        #endregion METODOS PRIVADOS
    }
}