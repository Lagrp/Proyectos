using Sgcm.UI.Desktop.Vistas;
using System;
using System.Windows;

namespace Sgcm.UI.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///

    public partial class App : Application
    {
        protected void ApplicationStart(Object sender, StartupEventArgs e)
        {
            LoginView login = new();
            login.Show();
            login.IsVisibleChanged += (s, ev) =>
            {
                if (login.IsVisible == false && login.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    login.Close();
                }
            };
        }
    }
}