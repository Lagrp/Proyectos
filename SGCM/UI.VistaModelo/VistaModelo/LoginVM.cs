using Soporte.Autentificacion;
using System.Windows.Input;

namespace UI.Desktop.VistaModelo
{
    public class LoginVM : NotifyVM
    {
        //Fields
        private string _username = "lagrp";

        private string _password = "luan3306";
        private string _errorMessage = "";
        private bool _isViewVisible = true;

        #region PROPIEDADES

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        #endregion PROPIEDADES

        //-> Commands
        public ICommand LoginCommand { get; }

        //public ICommand RecoverPasswordCommand { get; }
        //public ICommand ShowPasswordCommand { get; }
        //public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginVM()
        {
            LoginCommand = new CommandVM(ExecuteLoginCommand, CanExecuteLoginCommand);
            //RecoverPasswordCommand = new CommandVM(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            //Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            ValidarUsuario isValidUser = new();

            if (isValidUser.UsuarioValido(Username, Password))
            {
                App.IdUsuarioActivo = isValidUser.IdUsuarioValido;
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        //private void ExecuteRecoverPassCommand(string username, string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}