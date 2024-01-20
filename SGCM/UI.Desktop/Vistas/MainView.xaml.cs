using Sgcm.UI.Desktop.VistaModelo;
using System.Windows;

//using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Sgcm.UI.Desktop.Vistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private const double mSBarMin = 30;
        private const double mSBarMax = 120;

        private MainVM _vm = new();

        public MainView()
        {
            InitializeComponent();
            gSideBar.Width = mSBarMin;
            btCalen.IsChecked = false;
            btPizarra.IsChecked = true;
            gRBar.Visibility = Visibility.Collapsed;
            this.DataContext = _vm;
        }

        #region COMPORTAMIENTO SIDEBAR

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {
            EstSideBar(gSideBar.Width);
        }

        private void EstSideBar(double anchoActual)
        {
            gSideBar.Width = anchoActual > mSBarMin ? mSBarMin : mSBarMax;
        }

        private void btCalen_Click(object sender, RoutedEventArgs e)
        {
            gRBar.Visibility = btCalen.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btLogoff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NavView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _vm.MainViewSelectionChanged(sender, frWrap);
        }
    }

    #endregion COMPORTAMIENTO SIDEBAR
}