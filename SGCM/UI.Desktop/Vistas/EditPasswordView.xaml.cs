using System.Windows;
using System.Windows.Input;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para EditPasswordView.xaml
    /// </summary>
    public partial class EditPasswordView : Window
    {
        public EditPasswordView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btiPassCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}