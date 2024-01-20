using AppDTO;
using AppServices.Servicios;
using AppServices.ValueObjects;
using Dominio.Modelo.Entidades;
using System.Windows;
using System.Windows.Input;

namespace UI.Desktop.VistaModelo
{
    public class PerfilVM : NotifyVM
    {
        #region VARIABLES MIEMBRO

        private PerfilViewServicio _perfilViewServicio;

        //Variables de usuario
        private Usuario? _perfilUsuario;

        private Visibility _botonVisible;
        private bool _formActivo;
        private bool _botonActivo = true;

        //Variables de Persona
        private Persona? _perfilPersona;

        private DataAuxiliarVM _dataAuxiliar;
        private DistritoDto? _ubigeo;
        private TelefonoCollection? _misTelefonos;
        private EmailCollection? _emails;
        private RedCollection? _redes;
        private Telefono _telefonoActual;

        //objetos de valor
        public EntityState _estado;

        #region DEFINICION COMANDOS

        public ICommand EditCommand { get; }
        public ICommand CancelarCommand { get; }
        public ICommand GuardarCommand { get; }
        public ICommand AgregarTelefonoCommand { get; }
        public ICommand AgregarEmailCommand { get; }
        public ICommand AgregarRedCommand { get; }
        public ICommand EliminarTelefonoCommand { get; }
        public ICommand EliminarEmailCommand { get; }
        public ICommand EliminarRedCommand { get; }

        #endregion DEFINICION COMANDOS

        #endregion VARIABLES MIEMBRO

        #region CONSTRUCTORES

        public PerfilVM(int usu_Id)
        {
            DataAuxiliar = new DataAuxiliarVM();
            _perfilViewServicio = new();
            CargaUsuario(usu_Id);
            CancelarCommand = new CommandVM(ExecuteCancelarCommand);
            //GuardarCommand = new CommandVM(ExecuteGuardarCommand);
            EditCommand = new CommandVM(ExecuteEditCommand, CanExecuteEditCommand);
            AgregarTelefonoCommand = new CommandVM(ExecuteAgregarTelefonoCommand);
            AgregarEmailCommand = new CommandVM(ExecuteAgregarEmailCommand);
            AgregarRedCommand = new CommandVM(ExecuteAgregarRedCommand);
        }

        public PerfilVM()
        { }

        #endregion CONSTRUCTORES

        #region PROPIEDADES DE LA VISTA

        public DataAuxiliarVM DataAuxiliar
        {
            get => _dataAuxiliar;
            set
            {
                _dataAuxiliar = value;
                OnPropertyChanged(nameof(DataAuxiliar));
            }
        }

        public bool BotonActivo
        {
            get => _botonActivo;
            set
            {
                _botonActivo = value;
                OnPropertyChanged(nameof(BotonActivo));
            }
        }

        public Visibility BotonVisible
        {
            get => _botonVisible;
            set
            {
                _botonVisible = value;
                OnPropertyChanged(nameof(BotonVisible));
            }
        }

        public bool FormActivo
        {
            get => _formActivo;
            set
            {
                _formActivo = value;
                OnPropertyChanged(nameof(FormActivo));
            }
        }

        #endregion PROPIEDADES DE LA VISTA

        #region PROPIEDADES USUARIO

        public Usuario? PerfilUsuario
        {
            get => _perfilUsuario;
            set
            {
                _perfilUsuario = value;
                OnPropertyChanged(nameof(PerfilUsuario));
            }
        }

        #endregion PROPIEDADES USUARIO

        #region PROPIEDADES PERSONA

        public Persona? PerfilPersona
        {
            get => _perfilPersona;
            set
            {
                _perfilPersona = value;
                OnPropertyChanged(nameof(PerfilPersona));
            }
        }

        public DistritoDto? MiUbigeo
        {
            get => _ubigeo;
            set
            {
                _ubigeo = value;
                OnPropertyChanged(nameof(MiUbigeo));
            }
        }

        public TelefonoCollection? MisTelefonos
        {
            get => _misTelefonos;
            set
            {
                _misTelefonos = value;
                OnPropertyChanged(nameof(MisTelefonos));
            }
        }

        public EmailCollection? MisEmails
        {
            get => _emails;
            set
            {
                _emails = value;
                OnPropertyChanged(nameof(MisEmails));
            }
        }

        public RedCollection? MisRedes
        {
            get => _redes;
            set
            {
                _redes = value;
                OnPropertyChanged(nameof(MisRedes));
            }
        }

        public Telefono TelefonoActual
        {
            get => _telefonoActual;
            set
            {
                _telefonoActual = value;
                OnPropertyChanged(nameof(TelefonoActual));
            }
        }

        #endregion PROPIEDADES PERSONA

        #region METODOS PRIVADOS

        private void CargaUsuario(int usu_Id)
        {
            PerfilUsuario = _perfilViewServicio.GetUsuario(usu_Id);
            PerfilPersona = _perfilViewServicio.GetPersona(PerfilUsuario.Usu_personaId);
            MisTelefonos = _perfilViewServicio.GetTelefonos(PerfilUsuario.Usu_personaId);
            MisEmails = _perfilViewServicio.GetEmails(PerfilPersona.Per_Id);
            MisRedes = _perfilViewServicio.GetRedes(PerfilPersona.Per_Id);
            MiUbigeo = DataAuxiliar.GetDistrito(PerfilPersona.Per_ubigeo);
            BotonVisible = Visibility.Collapsed;
            BotonActivo = true;
            FormActivo = false;
        }

        #endregion METODOS PRIVADOS

        #region METODOS DE EJECUCION DE COMANDOS

        private bool CanExecuteEditCommand(object obj)
        {
            //bool validData;
            //if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
            //    Password == null || Password.Length < 3)
            //    validData = false;
            //else
            //    validData = true;
            //return validData;
            return true;
        }

        private void ExecuteEditCommand(object obj)
        {
            _estado = EntityState.Modified;
            FormActivo = true;
            BotonVisible = Visibility.Visible;
            BotonActivo = false;
        }

        //private void ExecuteGuardarCommand(object obj)
        //{
        //    string msg = new UsuarioServicio().GuardarCambios(PerfilUsuario, estado);
        //    msg = msg + " " + new PersonaServicio().GuardarCambios(PerfilPersona, estado);

        //    if (MisTelefonos.Count > 0)
        //    {
        //        foreach (Telefono telefono in MisTelefonos)
        //        {
        //            msg = msg + new TelefonoServicio().GuardarCambios(telefono, estado);
        //        }
        //    }

        //    if (string.IsNullOrEmpty(msg))
        //    {
        //        MessageBox.Show(msg);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Guardado exitosamente");
        //    }
        //    CargaUsuario(PerfilUsuario.Usu_Id);
        //}

        private void ExecuteCancelarCommand(object obj)
        {
            MisTelefonos.Clear();
            MisEmails.Clear();
            MisRedes.Clear();
            CargaUsuario(PerfilUsuario.Usu_Id);
        }

        public void ExecuteAgregarTelefonoCommand(object sender) => MisTelefonos.Add(new Telefono { Tel_perId = PerfilUsuario.Usu_personaId });

        public void ExecuteAgregarEmailCommand(object sender) => MisEmails.Add(new Email { Email_perId = PerfilUsuario.Usu_personaId });

        public void ExecuteAgregarRedCommand(object sender) => MisRedes.Add(new Red { Reus_perId = PerfilUsuario.Usu_personaId });

        #endregion METODOS DE EJECUCION DE COMANDOS
    }
}