using System.Windows.Controls;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Lógica de interacción para DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PersonEditView fr = new();
            fr.ShowDialog();
            
        }
    }
}